using UnityEngine;

using UnityEngine.InputSystem;
public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject gameWin;
    [SerializeField] private CharacterController player;
    [SerializeField] private GameManager gameManager;

    private int counter = 0;
    
    public bool IsLionSuccess { get; set; } = false;
    public bool IsOxSuccess { get; set; } = false;
    public bool IsDeerSuccess { get; set; } = false;

    public void Progress()
    {
        counter++;
        if (counter < 3) {
            SignalManager.Instance.EmitOnUnlockTheMask();
        }
        if (counter == 3)
        {
            CharacterController controller = player;
            if (controller != null) {
                controller.enabled = false;
            }

            gameWin.SetActive(true);
            gameManager.VisibleCursor(true);
        }
    }
}
