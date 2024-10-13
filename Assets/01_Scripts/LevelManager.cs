using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Este m�todo puede ser llamado cuando el jugador interact�a con el portal
    public void LoadNextLevel(string levelName)
    {
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene(levelName);
    }
}
