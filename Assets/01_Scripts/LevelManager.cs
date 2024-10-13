using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Este método puede ser llamado cuando el jugador interactúa con el portal
    public void LoadNextLevel(string levelName)
    {
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene(levelName);
    }
}
