using FMODUnity;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private FMOD.Studio.EventInstance music;
    public EventReference MusicEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            music = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
            music.start();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            music.release();
            Destroy(gameObject);
        }
    }

    public void SetMaskNone()
    {
    }

    public void SetMaskLion()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Mask", 1);
    }

    public void SetMaskStag()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Mask", 2);
    }

    public void SetMaskOx()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Mask", 3);
    }

    public void SetCharacterNone()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Character", 0);
    }

    public void SetCharacterLion()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Character", 1);
    }

    public void SetCharacterStag()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Character", 2);
    }

    public void SetCharacterOx()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Character", 3);
    }

    public void SetInGame(int value)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InGame", value);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            music.release();
        }
    }
}