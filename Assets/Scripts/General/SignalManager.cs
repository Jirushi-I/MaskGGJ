using UnityEngine;
using System;

public class SignalManager : MonoBehaviour
{
    public static SignalManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public event Action OnUnlockTheMask;
    public event Action<string> OnUnlockTheMaskSpecific;
   
    public void EmitOnUnlockTheMask() {
        OnUnlockTheMask?.Invoke();
    }
   
    public void EmitOnUnlockTheMaskSpecific(string nameMask) {
        OnUnlockTheMaskSpecific?.Invoke(nameMask);
    }
}
