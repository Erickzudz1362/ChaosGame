using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena
using UnityEngine.UI; // Necesario para usar el componente Text

public class PlayerHealth : MonoBehaviour
{
    public Text gameOverText; // Referencia al texto de Game Over

    private void Start()
    {
        // Aseg�rate de que el texto de Game Over est� oculto al inicio
        gameOverText.gameObject.SetActive(false);
    }

    public void Die()
    {
        // Desactiva al jugador
        gameObject.SetActive(false); // Cambia esto a Destroy(gameObject) si prefieres eliminarlo completamente

        // Verifica si ambos jugadores est�n muertos
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        // Verifica si ambos jugadores est�n inactivos
        PlayerController1 ecko = FindObjectOfType<PlayerController1>();
        PlayerController2 nova = FindObjectOfType<PlayerController2>();

        if ((ecko == null || !ecko.gameObject.activeSelf) && (nova == null || !nova.gameObject.activeSelf))
        {
            // Ambos jugadores est�n muertos, muestra el mensaje de Game Over
            Debug.Log("Game Over!"); // Mensaje en consola
            gameOverText.gameObject.SetActive(true); // Activa el texto de Game Over
            gameOverText.text = "Game Over! Press R to Restart"; // Mensaje de Game Over
        }
    }

    private void Update()
    {
        // Reiniciar la escena si se presiona R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
        }
    }
}
