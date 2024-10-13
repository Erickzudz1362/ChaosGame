using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDeath : MonoBehaviour
{
    // Detectar cuando un jugador toca el DeathWall
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que toca el DeathWall tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha ca�do. Reiniciando nivel...");

            // Reiniciar la escena actual, sin importar en qu� nivel est�s
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
