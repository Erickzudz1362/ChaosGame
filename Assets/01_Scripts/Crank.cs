using UnityEngine;

public class Crank : MonoBehaviour
{
    public GameObject[] doors; // Array de referencias a las puertas que se abrirán
    public float moveDistance = 2f; // Distancia que se moverán las puertas
    public float moveSpeed = 2f; // Velocidad de movimiento de las puertas
    private bool isActivated = false; // Estado de la palanca

    void Update()
    {
        // Verifica si se presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            ActivateCrank();
        }
    }

    void ActivateCrank()
    {
        isActivated = true; // Marca la palanca como activada
        foreach (GameObject door in doors)
        {
            StartCoroutine(OpenDoor(door)); // Inicia la coroutine para cada puerta
        }
    }

    private System.Collections.IEnumerator OpenDoor(GameObject door)
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
}
