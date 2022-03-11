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
    public GameObject privacyPolicyBox;
    public GameObject termsOfServiceBox;
    public GameObject statisticsBox;
    public GameObject tutorialBox;
    public GameObject pasarPaginaBox;
    public GameObject pasarPagina2Box;
    public GameObject audioOn;
    public GameObject audioOff;
    public GameObject sfxOn;
    public GameObject sfxOff;
    

    private Animator anim;

    void Awake()
    {
        sfxManager = GameObject.Find("FXManager");
        audioManager = GameObject.Find("MusicManager");
    }

    void Start()
    {
        /*if (Global.isPlayingMusic == false)
        {
            AudioOn();
        }*/
        CargarOpcionesAudio();
        InitialAudioControl();
    }

    //AUDIO
    public void AudioControl()
    {
        if (Global.canAudioPlay == true)
        {
           Global.canAudioPlay = false;
           PlayerPrefs.SetInt("audioControl", 0);
           AudioOff();
           Debug.Log("SOUND_OFF");
        } else 
        {
           Global.canAudioPlay = true;
           PlayerPrefs.SetInt("audioControl", 1);
           AudioOn();
           Debug.Log("SOUND_ON");
        }

    }

    public void InitialAudioControl()
    {
        if (Global.canAudioPlay == true)
        {
           AudioOn();
           Debug.Log("SOUND_OFF");
        } else 
        {
           AudioOff();
           Debug.Log("SOUND_ON");
        }
    }

    public void SFXControl()
    {
        if (Global.canSFXPlay == true)
        {
           Global.canSFXPlay = false;
            PlayerPrefs.SetInt("SFXControl", 0);
           Debug.Log("SFX_OFF");
        } else 
        {
           Global.canSFXPlay = true;
            PlayerPrefs.SetInt("SFXControl", 1);
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
    }

    public void ShowPrivacyPolicyMenu()
    {
        privacyPolicyBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HidePrivacyPolicyMenu()
    {
        privacyPolicyBox.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void ShowTermsOfServiceMenu()
    {
        termsOfServiceBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideTermsOfServiceMenu()
    {
        termsOfServiceBox.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void ShowStatisticsMenu()
    {
        statisticsBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideStatisticsMenu()
    {
        statisticsBox.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void ShowTutorialMenu()
    {
        tutorialBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HideTutorialMenu()
    {
        tutorialBox.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void ShowPasarPaginaMenu()
    {
        pasarPaginaBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HidePasarPaginaMenu()
    {
        pasarPaginaBox.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void ShowPasarPagina2Menu()
    {
        pasarPagina2Box.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void HidePasarPagina2Menu()
    {
        pasarPagina2Box.GetComponent<Animator>().SetInteger("StateBox", 2);
    }

    public void PlayGame()
    {
        Global.initialTime = Time.time;
        SceneManager.LoadScene("PSF");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    private void CargarOpcionesAudio(){
        if(PlayerPrefs.GetInt("audioControl", 1)==0){
            AudioOff();
            audioOff.SetActive (true);
            audioOn.SetActive (false);
        }else if(PlayerPrefs.GetInt("audioControl", 1)==1){
            AudioOn();
            audioOn.SetActive (true);
            audioOff.SetActive (false);
        }

        if(PlayerPrefs.GetInt("SFXControl",1)==0){
            Global.canSFXPlay = false;
            sfxOff.SetActive (true);
            sfxOn.SetActive (false);
        }else if(PlayerPrefs.GetInt("SFXControl", 1)==1){
            Global.canSFXPlay = true;
            sfxOn.SetActive (true);
            sfxOff.SetActive (false);
        }
    }

}