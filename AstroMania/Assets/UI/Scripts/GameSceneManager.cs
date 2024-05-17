using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}