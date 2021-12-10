using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIntro : MonoBehaviour
{
    AudioSource introSound;
    public AudioClip effectWhoosh;
    public AudioClip spaceSound;
    // Start is called before the first frame update
    void Start()
    {
        introSound = GetComponent<AudioSource>();
        

        StartCoroutine("SFXintro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SFXintro()
    {
        
        yield return new WaitForSeconds (0.5f);
        introSound.PlayOneShot(effectWhoosh, 0.7F);

        yield return new WaitForSeconds(0.5f);
        introSound.PlayOneShot(spaceSound, 0.7F);

        yield return new WaitForSeconds (3.1f);
        introSound.PlayOneShot(effectWhoosh, 0.7F);

    }
}
