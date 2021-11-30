using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip menuMusic;
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
}

