using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public string bus;

    void OnEnable()
    {
        
    }

    public void SetVolume(float volume)
    {
        FMODUnity.RuntimeManager.GetBus("bus:/" + bus).setVolume(volume);
    }
}