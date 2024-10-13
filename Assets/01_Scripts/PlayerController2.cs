using UnityEngine;

public class PlayerController2 : MonoBehaviour
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
    public AudioSource attackSound; // AudioSource para sonido de ataque

    private void Start()
    {
        animator.SetBool("Grounded", true);

        // Asignar el AudioSource para el sonido de salto (debe estar en el mismo objeto)
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Mirror();
        Jump2();
        Attack();
        animator.SetFloat("FallingSpeed", rb.velocity.y);
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal2"); // Usando un eje personalizado "Horizontal2" para el segundo jugador
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


    void Jump2()
    {
        // Permitir salto simple y doble
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canJump)
            {
                PerformJump(jumpForce); // Salto normal
                canDoubleJump = true; // Habilitar doble salto
            }
            else if (canDoubleJump)
            {
                PerformJump(doubleJumpForce); // Salto doble más débil
                canDoubleJump = false; // Deshabilitar doble salto después de usarlo
            }
        }
    }

    void PerformJump(float force)
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

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.O)) // Usando la tecla "O" para atacar
        {
            animator.SetTrigger("Attack");

            // Reproducir sonido de ataque
            if (attackSound != null)
            {
                attackSound.Play(); // Reproduce el sonido de ataque
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

}
