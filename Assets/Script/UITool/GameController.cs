using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void RestartGame()
    {
        //Obtener la seleccion previa de personaje
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        
        //Logica Reinicio de jeugo
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
