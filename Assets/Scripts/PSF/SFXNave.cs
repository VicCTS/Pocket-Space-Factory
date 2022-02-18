using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXNave : MonoBehaviour
{
    public AudioClip aterrizar;
    public AudioClip despegar;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAterrizar()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(aterrizar);
        }   
    }
    public void PlayDespegar()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(aterrizar);
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Aterrizar")
        {
            Debug.Log("Aterrizar");
            PlayAterrizar();
        }
        
        if (other.gameObject.tag == "Despegar")
        {
            Debug.Log("Despegar");
            PlayDespegar();
        }
    }
}   
    