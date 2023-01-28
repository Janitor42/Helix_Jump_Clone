using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    public AudioSource DestroyPlatformSound;
    public AudioSource SoundDeath;
    public AudioSource SoundWin;

    private AudioSource _Audio;


    public void Awake()
    {
        _Audio = GetComponent<AudioSource>();
        _Audio.volume = 0.01f;
    }
    public void SoundBackGroundOn()
    {
        _Audio.Play();
    }

    public void SoundBackGroundOff()
    {
        _Audio.Pause();
    }

    public void SoundDestroyPlatform()
    {
        DestroyPlatformSound.volume = 0.1f;
        DestroyPlatformSound.Play();
    }

    public void SoundYouDeath()
    {
        SoundDeath.volume = 0.1f;
        SoundDeath.Play();
    }
    public void SoundYouDeathOff()
    {
        SoundDeath.Stop();
    }
    public void SoundYouWin()
    {   
        SoundWin.volume = 0.1f;
        SoundWin.Play();
    }
    public void SoundYouWinOff()
    {
        SoundWin.Stop();
    }
}

