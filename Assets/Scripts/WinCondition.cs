using UnityEngine;

using UnityEngine.InputSystem;
public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    private int counter = 0;

    public void Progress()
    {
        counter++;
        //LocalMusicManager.PlaySucceedSound();
        if (counter < 3) {
            SignalManager.Instance.EmitOnUnlockTheMask();
        }
        if (counter == 3)
        {
            gameOver.SetActive(true);
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
