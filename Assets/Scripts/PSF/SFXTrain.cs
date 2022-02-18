using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrain : MonoBehaviour
{
    public AudioClip train;
    public AudioClip coming;
    public AudioClip leaving;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayComing()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(coming);
        }   
    }
    public void PlayLeaving()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(leaving);
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coming")
        {   
            Debug.Log("Llegada");
            PlayComing();
           
        }
        
        if (other.gameObject.tag == "Leaving")
        {
            Debug.Log("SeVa");
            PlayLeaving();
        }
    }

}
