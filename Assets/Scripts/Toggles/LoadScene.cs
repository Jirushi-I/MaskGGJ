
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private string SCENE_GAME = "Scenes/BU/BU_SCENE_DOMI";

    private string SCENE_MAIN_MENU = "Scenes/Game Start/MainMenu";

    void Start() {
        Cursor.visible = true;
    }

    public void LoadGameMenu() {
        SceneManager.LoadScene(SCENE_GAME);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(SCENE_MAIN_MENU);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
