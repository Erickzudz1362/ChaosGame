using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Animator playerAnimator; // Referencia al Animator del jugador
    public float attackRange = 1.5f; // Distancia a la que se puede atacar
    public LayerMask rockLayer; // Capa donde están las rocas

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // Si se presiona la tecla "O"
        {
            Attack();
        }
    }

    void Attack()
    {
        // Reproducir la animación de ataque
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Attack"); // Asegúrate de tener un trigger llamado "Attack" en tu Animator
        }

        // Comprobar si hay rocas en el rango de ataque
        Collider2D[] rocks = Physics2D.OverlapCircleAll(transform.position, attackRange, rockLayer);
        foreach (Collider2D rock in rocks)
        {
            Destroy(rock.gameObject); // Destruir la roca
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja un círculo en el editor para visualizar el rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
