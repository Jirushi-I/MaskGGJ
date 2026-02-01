
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private const string SCENE_GAME = "Scenes/BU/BU_SCENE_DOMI";

    public void LoadGameMenu() {
        SceneManager.LoadScene(SCENE_GAME);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
