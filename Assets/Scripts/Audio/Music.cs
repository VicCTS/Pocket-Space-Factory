using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip inGameMusic;
    public AudioClip gameOverMusic;
    public AudioClip victoyMusic;
    private AudioSource audioSource;
    private static Music musicInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuSoundtrack()
    {
        audioSource.clip = menuMusic;
        if (Global.canAudioPlay == true)
        {
            audioSource.Play();
        }
    }

    public void StopMenuSoundtrack()
    {
        audioSource.Stop();
    }
    
    public void PlayGameSoundtrack()
    {
         audioSource.clip = inGameMusic;
         if (Global.canAudioPlay == true)
        {
            audioSource.Play();
        }
    }
     public void PlayGameOverSoundtrack()
    {
         audioSource.clip = gameOverMusic;
         if (Global.canAudioPlay == true)
        {
            audioSource.Play();
        }
    }
    public void PlayVictorySoundtrack()
    {
         audioSource.clip = victoyMusic;
         if (Global.canAudioPlay == true)
        {
            audioSource.Play();
        }
    }
    
}

