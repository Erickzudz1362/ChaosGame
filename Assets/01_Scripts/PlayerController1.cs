using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 4f; // Velocidad de movimiento
    public float jumpForce = 7f; // Fuerza de salto
    public float doubleJumpForce = 5f; // Fuerza de doble salto
    public float pushForce = 5f; // Fuerza de empuje al chocar
    public Rigidbody2D rb; // Referencia al Rigidbody2D
    public Animator animator; // Referencia al Animator
    public bool canJump = true; // Controla si puede saltar
    private bool canDoubleJump = false; // Controla si puede hacer doble salto
    private AudioSource jumpSound; // AudioSource para sonido de salto
    public AudioSource actionSound; // AudioSource para sonido de ataque

    float xInitial, yInitial;

    private void Start()
    {
        // Obtiene el AudioSource en el Start
        jumpSound = GetComponent<AudioSource>();

        animator.SetBool("Grounded", true);
    }

    void Update()
    {
        Movement();
        Mirror();
        Jump();
        Action();
        animator.SetFloat("FallingSpeed", rb.velocity.y);
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal1");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(x));
    }
void Mirror()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Mira hacia la izquierda
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Mira hacia la derecha
        }
    }


    void Jump()
    {
        // Permitir salto simple y doble
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canJump)
            {
                PerformJump();
                canDoubleJump = true; // Habilitar doble salto
            }
            else if (canDoubleJump)
            {
                PerformJump();
                canDoubleJump = false; // Deshabilitar doble salto después de usarlo
            }
        }
    }

    void PerformJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        canJump = false;
        animator.SetBool("Grounded", false);

        // Reproduce el sonido de salto si el AudioSource está presente
        if (jumpSound != null)
        {
            jumpSound.Play();
        }
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Action");
            if (actionSound != null)
            {
                actionSound.Play(); // Reproduce el sonido de ataque
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animator.SetBool("Grounded", true);
        }
        else if (collision.gameObject.CompareTag("Player")) // Verifica si colisiona con otro jugador
        {
            // Solo aplica empuje si el jugador en movimiento tiene una velocidad significativa
            if (Mathf.Abs(rb.velocity.x) > 0.1f) // Ajusta el valor según lo que consideres movimiento significativo
            {
                // Calcula la dirección de empuje
                Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // Normaliza la dirección
                rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Aplica la fuerza de empuje
            }
        }
    }


    public void Resurect()
    {
        transform.position = new Vector3(xInitial, yInitial, 0);
    }
}
