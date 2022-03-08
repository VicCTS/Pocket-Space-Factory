using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBox : MonoBehaviour
{
    public AudioClip CajaSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCajaSFX()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(CajaSFX, 1f);   
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CajaHoyo")
        {
            PlayCajaSFX();
        }
    }

}
