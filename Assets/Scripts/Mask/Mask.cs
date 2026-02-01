using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public abstract class Mask: MonoBehaviour {

    //[SerializeField] protected GameObject visualMask;
    [SerializeField] protected Image filterColorImage;
    [SerializeField] protected string maskName;
    [SerializeField] protected bool isUnlock = false;
    [SerializeField] protected Material visionMaterial;
    [SerializeField] protected MaskTransition maskTransition;
    [SerializeField] protected Image imageMask;
    [SerializeField] protected Sprite imageDefaultMask;

    protected bool isEquipped = false;
    protected Color defaultFilterColors;


    public void Start() {
        if (filterColorImage != null)
        {
            defaultFilterColors = new Color(0, 0, 0, 0);
        }
        Debug.Log(imageMask);
        //visualMask?.SetActive(false);
    }

    public bool IsEquipped => isEquipped;
    public string MaskName => maskName;
    public bool IsUnlockMask => isUnlock;

    public virtual void Equip()
    {
        if (isUnlock)
            Debug.Log(maskName + "is not unlock yet ");

        if (!isEquipped && isUnlock)
        {
            if (maskTransition != null) {
                maskTransition.TransitionToMask(() => {
                    ApplyCameraEffect();
                    Debug.Log("Masque équipé!");
                });
            } else {
                // Pas de transition, application directe
                ApplyCameraEffect();
            }

            isEquipped = true;
            //visualMask?.SetActive(true);
        }

    }
    public virtual void Unequip()
    {

        Debug.Log("Here");
        if (isEquipped) {
            if (maskTransition != null) {
                maskTransition.TransitionFromMask(() => {
                    RemoveCameraEffect();
                    Debug.Log("Masque retiré!");
                });
            } else {
                RemoveCameraEffect();
            }

            isEquipped = false;
            //visualMask?.SetActive(false);
        }

        Debug.Log("Unequipped " + maskName);
    }
    public virtual void Unlock() {
        if (isUnlock) {
            Debug.Log(maskName + "is already unlock");
        }

        isUnlock = true;
        Debug.Log(maskName + "is unlock");
    }

    protected abstract void ApplyCameraEffect();
    protected abstract void RemoveCameraEffect();
    protected abstract void UpdateMaterial();

}