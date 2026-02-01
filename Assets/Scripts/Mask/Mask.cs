using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public abstract class Mask: MonoBehaviour {

    [SerializeField] protected GameObject visualMask;
    [SerializeField] protected Image filterColorImage;
    [SerializeField] protected string maskName;
    [SerializeField] protected bool isUnlock = false;
    [SerializeField] protected Material visionMaterial;

    protected bool isEquipped = false;
    protected Color defaultFilterColors;


    public void Start() {
        if (filterColorImage != null)
        {
            defaultFilterColors = new Color(0, 0, 0, 0);
        }

        visualMask?.SetActive(false);
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
            isEquipped = true;
            visualMask?.SetActive(true);
            ApplyCameraEffect();
            Debug.Log("Equipped " + maskName);
        }

    }
    public virtual void Unequip()
    {
        if (isEquipped)
        {
            isEquipped = false;
            visualMask?.SetActive(false);
            RemoveCameraEffect();
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