
using UnityEngine;

public class LocalMusicManager : MonoBehaviour
{

    public void SetMaskNone()
    {
        MusicManager.Instance.SetMaskNone();
    }

    public void SetMaskLion()
    {
        MusicManager.Instance.SetMaskLion();
    }

    public void SetMaskStag()
    {
        MusicManager.Instance.SetMaskStag();
    }

    public void SetMaskOx()
    {
        MusicManager.Instance.SetMaskOx();
    }

    public void SetCharacterNone()
    {
        MusicManager.Instance.SetCharacterNone();
    }

    public void SetCharacterLion()
    {
        MusicManager.Instance.SetCharacterLion();
    }

    public void SetCharacterStag()
    {
        MusicManager.Instance.SetCharacterStag();
    }

    public void SetCharacterOx()
    {
        MusicManager.Instance.SetCharacterOx();
    }

    public void SetInGame(int value)
    {
        MusicManager.Instance.SetInGame(value);
    }

    public void PlayInteractSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Interact");
    }

    public void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Button");
    }

    public void PlaySucceedSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Succeed");
    }

    public void PlayFailSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Fail");
    }
}