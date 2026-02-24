using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string bus;
    [SerializeField] private Slider slider;

    void OnEnable()
    {
        float savedVolume = PlayerPrefs.GetFloat(bus, 1f);
        slider.value = savedVolume;
        FMODUnity.RuntimeManager.GetBus("bus:/" + bus).setVolume(savedVolume);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(bus, volume);
        FMODUnity.RuntimeManager.GetBus("bus:/" + bus).setVolume(volume);
    }
}