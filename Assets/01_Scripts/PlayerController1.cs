using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 4f; // Velocidad de movimiento de Ecko
    public float jumpForce = 7f; // Fuerza de salto
    public Rigidbody2D rb; // Referencia al Rigidbody2D para aplicar físicas
    public Animator animator; // Referencia al Animator para controlar las animaciones
    public bool canJump = true; // Controla si puede saltar 
    private AudioSource jumpSound; // Referencia al AudioSource para reproducir sonido
    public AudioSource actionSound;

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
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.W))
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
    }

    public void Resurect()
    {
        transform.position = new Vector3(xInitial, yInitial, 0);
    }
}
