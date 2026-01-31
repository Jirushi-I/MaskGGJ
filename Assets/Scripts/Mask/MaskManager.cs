using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MaskManager : MonoBehaviour {
    public static MaskManager Instance { get; private set; }

    [SerializeField] private Mask[] availableMasks;
    [SerializeField] private Camera playerCamera;

    private Mask currentMask;
    private int currentMaskIndex = -1;

    void Start () {
        Instance = this;
    }

    void Update () {

        if (Keyboard.current.digit1Key.wasPressedThisFrame) {
            EquipMask(0);
        } else if (Keyboard.current.digit2Key.wasPressedThisFrame) {
            EquipMask(1);
        } else if (Keyboard.current.digit3Key.wasPressedThisFrame) {
            EquipMask(2);
        } else if (Keyboard.current.digit0Key.wasPressedThisFrame) {
            UnequipCurrentMask();
        }
    }

    public Mask GetCurrentMask()
    {
        return currentMask;
    }


    private void EquipMask(int index) {
        // Check if the index is within the valid range
         if (index < 0 || index >= availableMasks.Length)
        {
            Debug.LogWarning("Invalid mask index!");
            return;
        }

        // Check if the mask is already equipped
        if (currentMaskIndex == index && currentMask != null && currentMask.IsEquipped)
        {
            Debug.Log("Mask already equipped!");
            return;
        }

        // Unequip the current mask
        if (currentMask != null && currentMask.IsEquipped)
        {
            currentMask.Unequip();
        }

        currentMaskIndex = index;
        currentMask = availableMasks[index];
        currentMask.Equip();
    }

       public void UnequipCurrentMask()
    {
        if (currentMask != null && currentMask.IsEquipped)
        {
            currentMask.Unequip();
            currentMask = null;
            currentMaskIndex = -1;
        }
    }
}