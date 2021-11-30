using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")]
    public string sceneDestinationName;

    [Header("Player")]
    public GameObject player;

    [Header("Audio")]
    public GameObject audioManager;
    public GameObject sfxManager;

    [Header("UI")]
    public GameObject playBox;
    public GameObject creditsBox;
    public GameObject optionsBox;
    public GameObject exitBox;

    private Animator anim;

    void Start()
    {
        if (Global.isPlayingMusic == false)
        {
            AudioOn();
        }
    }

    //AUDIO
    public void AudioControl()
    {
        if (Global.canAudioPlay == true)
        {
           Global.canAudioPlay = false;
           AudioOff();
           Debug.Log("SOUND_OFF");
        } else 
        {
           Global.canAudioPlay = true;
           AudioOn();
           Debug.Log("SOUND_ON");
        }
    }

    public void SFXControl()
    {
        if (Global.canSFXPlay == true)
        {
           Global.canSFXPlay = false;
           Debug.Log("SFX_OFF");
        } else 
        {
           Global.canSFXPlay = true;
           Debug.Log("SFX_ON");
        }
    }

    public void AudioOn()
    {
        Global.canAudioPlay = true;
        audioManager.GetComponent<Music>().PlayMenuSoundtrack();
        Global.isPlayingMusic = true;
        Debug.Log("SOUND_ON_2");
    }

    public void AudioOff()
    {
        Global.canAudioPlay = false;
        audioManager.GetComponent<Music>().StopMenuSoundtrack();
        Global.isPlayingMusic = false;
        Debug.Log("SOUND_OFF_2");
    }

 
    //MENU
    public void ShowPlayMenu()
    {
        playBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HidePlayMenu()
    {
        playBox.GetComponent<Animator>().SetInteger("StateBox", 2);
        player.GetComponent<RayMenu>().ReturnToStartPoint();
    }

    public void ShowOptionsMenu()
    {
        optionsBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideOptionsMenu()
    {
        optionsBox.GetComponent<Animator>().SetInteger("StateBox", 2);
        player.GetComponent<RayMenu>().ReturnToStartPoint();
    }

    public void ShowExitMenu()
    {
        exitBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideExitMenu()
    {
        exitBox.GetComponent<Animator>().SetInteger("StateBox", 2);
        player.GetComponent<RayMenu>().ReturnToStartPoint();
    }

    public void ShowCreditsMenu()
    {
        creditsBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideCreditsMenu()
    {
        creditsBox.GetComponent<Animator>().SetInteger("StateBox", 2);
        player.GetComponent<RayMenu>().ReturnToStartPoint();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PSF");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
