using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private Sprite noMaskSprite;
    [SerializeField] private Sprite maskLionSprite;
    [SerializeField] private Sprite maskOxSprite;
    [SerializeField] private Sprite maskDeerSprite;

    [SerializeField] private MaskManager maskManager;

    public Sprite GetCurrentMaskSprite() {
        if (maskManager == null) return noMaskSprite;

        Mask currentMask = maskManager.GetCurrentMask();

        if (currentMask == null) return noMaskSprite;

        switch (currentMask.MaskName) {
            case "Lion":
                return maskLionSprite;
            case "Ox":
                return maskOxSprite;
            case "Deer":
                return maskDeerSprite;
            default:
                return noMaskSprite;
        }
    }
}