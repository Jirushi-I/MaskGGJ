using UnityEngine;

public class MaskTriggerButton : MonoBehaviour
{
    public string maskName = "Lion"; // Nom du masque à débloquer

    // Fonction appelée par le bouton
    public void UnlockThisMask() {
        if (SignalManager.Instance != null) {
            SignalManager.Instance.EmitOnUnlockTheMaskSpecific(maskName);
            Debug.Log("Signal envoyé pour débloquer : " + maskName);
        } else {
            Debug.LogError("SignalManager n'existe pas !");
        }
    }
}
