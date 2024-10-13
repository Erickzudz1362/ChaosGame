using UnityEngine;

public class Portal : MonoBehaviour
{
    public LevelManager levelManager;
    public string sceneToLoad = "Level2";

    private bool player1Entered = false;
    private bool player2Entered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactivar el primer jugador cuando entra
            if (other.gameObject.name == "Player1" && !player1Entered)
            {
                player1Entered = true;
                Debug.Log("Player1 ha entrado al portal y ha desaparecido");
                other.gameObject.SetActive(false); // Desactivar Player1
            }
            else if (other.gameObject.name == "Player2" && !player2Entered)
            {
                player2Entered = true;
                Debug.Log("Player2 ha entrado al portal y ha desaparecido");
                other.gameObject.SetActive(false); // Desactivar Player2
            }
        }

        if (player1Entered && player2Entered)
        {
            Debug.Log("Ambos jugadores han entrado, cargando la siguiente escena...");
            levelManager.LoadNextLevel(sceneToLoad);
        }
    }
}
