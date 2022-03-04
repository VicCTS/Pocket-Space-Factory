using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMeteor : MonoBehaviour
{
    public AudioClip[] meteor;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMeteor()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(meteor[Random.Range(0,2)], 1f);
        }   
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Meteor")
        {
            PlayMeteor();
        }
    }
}
