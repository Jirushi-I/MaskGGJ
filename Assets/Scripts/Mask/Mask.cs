using UnityEngine;
using UnityEngine.UI;

public abstract class Mask: MonoBehaviour {

    [SerializeField] protected GameObject visualMask; //TODO make the good Type
    [SerializeField] protected Image filterColorImage;
    [SerializeField] protected string maskName;

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

    public virtual void Equip()
    {
        if (!isEquipped)
        {
            isEquipped = true;
            visualMask?.SetActive(true);
            ApplyCameraEffect();
        }

        Debug.Log("Equipped " + maskName);
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


    protected abstract void ApplyCameraEffect();
    protected abstract void RemoveCameraEffect();
}