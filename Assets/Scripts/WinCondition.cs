using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int counter = 0;
    public GameObject winscreen;
    public SignalManager signalManager;
    public string unlock;
    public void Progress()
    {
        counter++;
        signalManager.EmitOnUnlockTheMask(unlock);

        if (counter == 3)
        {
            winscreen.SetActive(true);
        }
    }
}
