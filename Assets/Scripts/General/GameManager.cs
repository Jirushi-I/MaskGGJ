using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    bool isPaused = false;
    bool cursorVisibleBeforePause = false;

    void Start() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                TogglePause();
            }
        }
    }

    public void VisibleCursor(bool isVisible) {
        Cursor.visible = isVisible;
    }

    public void ControllerEnabled(bool isEnabled, CharacterController controllerplayer ) {
        if (controllerplayer != null)
            controllerplayer.enabled = isEnabled;
    }

    public void TogglePause() {
        if (!isPaused)
            cursorVisibleBeforePause = Cursor.visible;

        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.visible = isPaused ? true : cursorVisibleBeforePause;
    }
}
