using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 4f; // Velocidad de movimiento de Nova
    public float jumpForce = 7f; // Fuerza de salto
    public Rigidbody2D rb; // Referencia al Rigidbody2D para aplicar físicas
    public Animator animator; // Referencia al Animator para controlar las animaciones
    public bool canJump = true; // Controla si puede saltar
    private AudioSource jumpSound; // Referencia al AudioSource para reproducir sonido de salto
    public AudioSource attackSound; // Referencia al AudioSource para reproducir sonido de ataque

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
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump2()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.I)) // Usando la tecla "I" para saltar
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
                animator.SetBool("Grounded", false);
                if (jumpSound != null)
                {
                    jumpSound.Play(); // Reproduce el sonido de salto
                }
            }
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
    }
}
