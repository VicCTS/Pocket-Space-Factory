using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCrane : MonoBehaviour
{
    public AudioClip crane;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCrane()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(crane);
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crane")
        {
            Debug.Log("Crane");
            PlayCrane();
        }
        
    }
}
