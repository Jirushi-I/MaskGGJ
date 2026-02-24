using UnityEngine;

using UnityEngine.InputSystem;
public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject gameWin;
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
            gameWin.SetActive(true);
        }
    }


}
