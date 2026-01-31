using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MaskManager : MonoBehaviour {
    public static MaskManager Instance { get; private set; }

    [SerializeField] private Mask[] availableMasks;
    [SerializeField] private Camera playerCamera;

    private Mask currentMask;
    private int currentMaskIndex = -1;

    public void OnEnable() {
        Instance = this;
        SignalManager.Instance.OnUnlockTheMask += UnlockMask;
    }

    public void OnDisable() {
        SignalManager.Instance.OnUnlockTheMask -= UnlockMask;
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

        if (!currentMask.IsUnlockMask) {
            Debug.LogWarning(currentMask + " is not unlock");
            return;
        }

        currentMask.Equip();
    }

    private void UnlockMask(string maskName) {
        foreach (var mask in availableMasks) {
            if (mask.MaskName == maskName) {
                mask.Unlock();
                return;
            }
        }
        Debug.LogWarning($"Mask '{maskName}' not found!");
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