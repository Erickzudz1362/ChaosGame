using UnityEngine;

public class Crank : MonoBehaviour
{
    public GameObject door; // Referencia a la puerta que se abrirá
    public float moveDistance = 2f; // Distancia que se moverá la puerta
    public float moveSpeed = 2f; // Velocidad de movimiento de la puerta
    private bool isActivated = false; // Estado de la palanca
    private bool playerInRange = false; // Estado de proximidad del jugador

    void Update()
    {
        // Verifica si se presiona la tecla E y el jugador está en rango
        if (Input.GetKeyDown(KeyCode.E) && !isActivated && playerInRange)
        {
            ActivateCrank();
        }
    }

    void ActivateCrank()
    {
        isActivated = true; // Marca la palanca como activada
        StartCoroutine(OpenDoor());
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        Vector3 targetPosition = door.transform.position + new Vector3(-moveDistance, 0, 0); // Calcula la nueva posición de la puerta

        // Mueve la puerta hacia la posición objetivo
        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // Espera hasta el siguiente frame
        }

        // Destruye la puerta después de abrirse
        Destroy(door);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            playerInRange = true; // Marca que el jugador está en rango
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false; // Marca que el jugador ha salido del rango
        }
    }
}
