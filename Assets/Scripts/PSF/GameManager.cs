using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;
    public Sprite box1;
    public Sprite box2;
    public Sprite box3;
    public float waitTimeUnpause;

    [Header("UI Boxes")]
    public GameObject boxLevelFail;
    public GameObject boxLevelSuccess;
    public GameObject boxGameEnd;
    public GameObject pauseBox;

    [Header("State")]
    public bool isPlaying;           //Determina si estamos jugando o no. Hace referencia a cuando ponemos pause.
    public int actualLevel;          //Nivel actual.
   
    [Header("Machines")]
    public int totalBoxes;
    public int actualBox;
    public int actualBoxType;

    private SFXManager sfxManager;
    private Music soundManager;
    private Machine2 machine2;
    private Machine1 machine1;
    private Machine3 machine3;
    private PlayerController playerController;

    private void Awake() 
    {
        machine2 = GetComponent<Machine2>();
        machine3 = GetComponent<Machine3>();
        machine1 = GetComponent<Machine1>();
        sfxManager = GameObject.Find("FXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("MusicManager").GetComponent<Music>();
        isPlaying = false;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start() 
    {
        Global.score = 0;
        Global.maxTime = 0;
      //  boxGameEnd.SetActive(false);
        LoadLevel(Global.level);

        //Provisional
        ShowScoreInfo();
        StrtGame();
            Debug.Log("NIVELLMAX: " + Global.maxLevelPublished);
            Debug.Log("MAXLVLARRIBAT: " + Global.maxLevel);

        soundManager.PlayGameSoundtrack();
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
        soundManager.GetComponent<Music>().PlayGameSoundtrack();
        Global.isPlayingMusic = true;
        Debug.Log("SOUND_ON_2");
    }

    public void AudioOff()
    {
        Global.canAudioPlay = false;
        soundManager.GetComponent<Music>().StopMenuSoundtrack();
        Global.isPlayingMusic = false;
        Debug.Log("SOUND_OFF_2");
    }

   public void LoadLevel(int num)
   {
       // 1 - red box
       // 2 - Yellow box
       // 3 - blue box

       Global.requestBox.Clear();
       if (num == 1) 
       {
           Debug.Log("PUNTUACIÓMAXIMAAQUESTNIVELL: "+ Global.maxScore);
           Debug.Log("NIVELLACTUAL: "+ num);
            Global.requestBox.Add(2);
            //Global.requestBox.Add(2);
            //Global.requestBox.Add(2);

            Global.machine1BoxTime = 25;
            Global.machine2BoxTime = 10;
            Global.machine3BoxTime = 15;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;
        }
        if (num == 2)
        {
            Debug.Log("NIVELLACTUAL: "+ num);
            //TO DO
            Global.requestBox.Add(3);
         //   Global.requestBox.Add(2);
         //   Global.requestBox.Add(2);

            Global.machine1BoxTime = 25;
            Global.machine2BoxTime = 10;
            Global.machine3BoxTime = 15;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;
        }
       actualBox = 0;
       totalBoxes = Global.requestBox.Count;
       actualBoxType = Global.requestBox[actualBox];
       actualLevel = num;
   } 

   private void StrtGame()
   {
       machine1.StartMachine1();
       machine2.StartMachine2();
       machine3.StartMachine3();
       isPlaying = true; 
   }

    public void PauseGame()
    {
        playerController.cantMove = true;
        machine2.PauseMachine2();
        machine1.PauseMachine1();
        machine3.PauseMachine3();
        isPlaying = false;
    }

    private void unPauseGame()
    {
        playerController.cantMove = false;
        machine2.PlayMachine2();
        machine1.PlayMachine1();
        machine3.PlayMachine3();
        isPlaying = true;
    }

    public void UpdateBox()
    {
        actualBox++;
        if(actualBox < totalBoxes)
        {
            actualBoxType = Global.requestBox[actualBox];
            Global.score+=1;
        }else
        {
            if( Global.level < Global.maxLevelPublished){
            Debug.Log("victory");
           /*  ScoreFinal(); //Suma punts Work in progres
            if(Global.maxScore < Global.score){
                Global.maxScore = Global.score; 
                Debug.Log("HAS SUPERAT EL TEU RECORD: "+ Global.maxScore);
            } */
            ShowLevelCompleted();
                if(Global.maxLevel < Global.level){
                    Global.maxLevel = Global.level;
                    Debug.Log("Max Level POSTWIN: " + Global.maxLevel);
                }
            Global.level ++;
            } else{
                Debug.Log("victoryEPICA");
                ShowGameCompleted();
                if(Global.maxLevel < Global.level){
                    Global.maxLevel = Global.level;
                }
            }
        }
    }

    public void ShowScoreInfo()
    {
        scoreText.text = Global.score.ToString();
    }

    public void ShowGameOver()
    {
        boxLevelFail.GetComponent<Animator>().SetInteger("StateBox", 1);
        soundManager.PlayGameOverSoundtrack();
        PauseGame();
    }

    public void ShowLevelCompleted()
    {
        playerController.cantMove = true;
        PauseGame();
        boxLevelSuccess.GetComponent<Animator>().SetInteger("StateBox", 1);
        soundManager.PlayVictorySoundtrack();
        
    }

    public void ShowGameCompleted()
    {
        playerController.cantMove = true;
        PauseGame();
        boxGameEnd.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    //BUTTONS
    public void GoToMainMenu()
    {
        Global.level = 1;
        sfxManager.PlayStandardClick();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGameButton()
    {
        sfxManager.PlayStandardClick();
        if (isPlaying == true)
        {
            PauseGame();
            ShowPauseMenu();
            //playerController.cantMove = true;
        } else
        {
            StartCoroutine(HidePauseMenu());
            //playerController.cantMove = false;
        }
    }

    public void NextLevel(){
        LoadLevel(Global.level);      
        ShowScoreInfo();
        StrtGame();
        PlayGame();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PSF");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("PSF");
    }

    public void ScoreFinal()
    {

    }

    public void ShowPauseMenu()
    {
        pauseBox.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    IEnumerator HidePauseMenu()
    {
        pauseBox.GetComponent<Animator>().SetInteger("StateBox", 2);
        yield return new WaitForSeconds(waitTimeUnpause);
        unPauseGame();
    }
}
