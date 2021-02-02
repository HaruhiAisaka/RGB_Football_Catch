using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public int currentSceneIndex;

    PlayerControls controls;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
