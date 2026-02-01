using UnityEngine;

using UnityEngine.InputSystem;
public class WinCondition : MonoBehaviour
{
    private int counter = 0;
    public GameObject winscreen;

    public void Progress()
    {
        counter++;
        if (counter == 2)
        {
            winscreen.SetActive(true);
        }
    }

    //void Update() {

    //     if (Keyboard.current.digit7Key.wasPressedThisFrame) {
    //        SignalManager.Instance.EmitOnUnlockTheMask();
    //    }else if (Keyboard.current.digit8Key.wasPressedThisFrame) {
    //        SignalManager.Instance.EmitOnUnlockTheMaskSpecific("Deer");
    //    }
    //}
}
