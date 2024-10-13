using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public LevelManager levelManager; // Asigna el LevelManager en el inspector.
    public string sceneToLoad = "Level3"; // Asegúrate de que el nombre sea exactamente el del Level 3.

    private bool player1Entered = false;
    private bool player2Entered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Identificar a los jugadores por el nombre de su GameObject
            if (other.gameObject.name == "Player1" && !player1Entered)
            {
                player1Entered = true;
                Debug.Log("Player1 ha entrado al portal");
                other.gameObject.SetActive(false); // Hacer desaparecer a Player1
            }
            else if (other.gameObject.name == "Player2" && !player2Entered)
            {
                player2Entered = true;
                Debug.Log("Player2 ha entrado al portal");
                other.gameObject.SetActive(false); // Hacer desaparecer a Player2
            }
        }

        // Verificar si ambos jugadores han entrado
        if (player1Entered && player2Entered)
        {
            Debug.Log("Ambos jugadores han entrado, cargando Level 3...");
            levelManager.LoadNextLevel(sceneToLoad); // Cargar la escena del Level 3
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Restablecer el estado si un jugador sale del portal
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.name == "Player1")
            {
                player1Entered = false;
                Debug.Log("Player1 ha salido del portal");
            }
            else if (other.gameObject.name == "Player2")
            {
                player2Entered = false;
                Debug.Log("Player2 ha salido del portal");
            }
        }
    }
}
