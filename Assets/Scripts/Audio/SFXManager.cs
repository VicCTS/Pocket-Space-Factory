using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
  //declarando los clips
    public AudioClip SliderOn;
    public AudioClip SliderOff;
    public AudioClip StandardClick;
    public AudioClip CloseButton;
    public AudioClip paso1;
    public AudioClip paso2;
    public AudioClip agarrarCaja;
    public AudioClip tirarCaja;
    public AudioClip naveDespega;
    public AudioClip naveAterriza;
    public AudioClip trenEnMarcha;
    public AudioClip trenLlegando;
    public AudioClip trenYendose;
    public AudioClip gruaEnMovimiento;
    public AudioClip cajetinMina;//Segundo Sonido de la maquina 2_MINA_

    private AudioSource audioSource;
    private static SFXManager musicInstance;
    
    //Que no se destruya el sonido al cambiar de escena
    void Awake()
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
    //iniciando los clips de audio
    public void PlaySliderOn()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(SliderOn, 1f);
        }
    }

    public void PlaySliderOff()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(SliderOff, 1f);
        }  
    }

    public void PlayStandardClick()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(StandardClick, 1f);
        }
            
    }

    public void PlayCloseButton()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(CloseButton, 1f);
        }   
    }
    public void PlayPaso1()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(paso1, 1f);
        }   
    }
    public void PlayPaso2()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(paso2, 1f);
        }   
    }
    public void PlayAgarrarCaja()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(agarrarCaja, 1f);
        }   
    }
    public void PlayTirarCaja()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(tirarCaja, 1f);
        }   
    }
    public void PlayNaveDespega()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(naveDespega, 1f);
        }   
    }
    public void PlayNaveAterriza()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(naveAterriza, 1f);
        }   
    }
    public void PlayTrenEnMarcha()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(trenEnMarcha, 1f);
        }   
    }
    public void PlayTrenLlegando()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(trenLlegando, 1f);
        }   
    }
    public void PlayTrenYendose()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(trenYendose, 1f);
        }   
    }
    public void PlayGruaEnMovimiento()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(gruaEnMovimiento, 1f);
        }   
    }
    public void PlayCajetinMina()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(cajetinMina, 1f);
        }   
    }
    
}
