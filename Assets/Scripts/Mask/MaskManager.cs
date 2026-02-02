using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Linq;
using UnityEngine.UI;


public class MaskManager : MonoBehaviour {
    public static MaskManager Instance { get; private set; }

    [SerializeField] private Mask[] availableMasks;

    private Mask currentMask;
    private int currentMaskIndex = -1;

    private Mask[] unlockedListMask;

    public void OnEnable() {
        Instance = this;
        unlockedListMask = new Mask[0];


        SignalManager.Instance.OnUnlockTheMask += UnlockMask;
        SignalManager.Instance.OnUnlockTheMaskSpecific += UnlockMaskSpecific;
    }

    public void OnDisable() {
        SignalManager.Instance.OnUnlockTheMask -= UnlockMask;
        SignalManager.Instance.OnUnlockTheMaskSpecific -= UnlockMaskSpecific;
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
            Debug.Log("Test");
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

    private Mask GetRandomLockedMask() {
        Mask[] lockedMasks = availableMasks.Where(mask => !unlockedListMask.Contains(mask)).ToArray();


        if (lockedMasks.Length == 0) {
            Debug.Log("Tous les masques sont d�j� d�bloqu�s !");
            return null;
        }

        // Choisis un masque al�atoire parmi les masques verrouill�s
        int randomIndex = Random.Range(0, lockedMasks.Length);
        return lockedMasks[randomIndex];
    }

    private void UnlockMask() {
        Mask newMask = GetRandomLockedMask();

        if (newMask != null) {

            System.Array.Resize(ref unlockedListMask, unlockedListMask.Length + 1);
            unlockedListMask[unlockedListMask.Length - 1] = newMask;

            FMODUnity.RuntimeManager.PlayOneShot("event:/Succeed");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SucceedDialogue", 1);

            Debug.Log("Nouveau masque d�bloqu� : " + newMask.name);
        } else {
            Debug.Log("Aucun nouveau masque � d�bloquer");
            return;
        }
        newMask.Unlock();
    }

    private void UnlockMaskSpecific(string maskName) {
        foreach (var mask in availableMasks) {
            if (mask.MaskName == maskName) {
                mask.Unlock();
                System.Array.Resize(ref unlockedListMask, unlockedListMask.Length + 1);
                unlockedListMask[unlockedListMask.Length - 1] = mask;
            }
        }
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