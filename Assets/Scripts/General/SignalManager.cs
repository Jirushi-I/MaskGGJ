using UnityEngine;
using System;

public class SignalManager : MonoBehaviour
{
    public static SignalManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public event Action<string> OnUnlockTheMask;
   
    public void EmitOnUnlockTheMask(string nameMask) {
        OnUnlockTheMask?.Invoke(nameMask);
    }
}
