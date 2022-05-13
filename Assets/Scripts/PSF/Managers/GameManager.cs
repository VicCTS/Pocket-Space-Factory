using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;
    public Sprite box1;
    public Sprite box2;
    public Sprite box3;
    public float waitTimeUnpause;
    public GameObject camDrag;

    [Header("UI Boxes")]
    public GameObject boxLevelFail;
    public GameObject boxLevelSuccess;
    public GameObject boxGameEnd;
    public GameObject pauseBox;
    public GameObject fundido;

    [Header("State")]
    public bool isPlaying;           //Determina si estamos jugando o no. Hace referencia a cuando ponemos pause.
    public int actualLevel;          //Nivel actual.
   
    [Header("Machines")]
    public int totalBoxes;
    public int actualBox;
    public int actualBoxType;

    private SFXManager sfxManager;
    private Music soundManager;
    public Machine2 machine2;
    public Machine1 machine1;
    public Machine3 machine3;
    public PlayerController playerController;

    [Header("Timeline Assets")]
    public GameObject boxAnim1;
    public GameObject boxAnim2;
    public GameObject boxAnim3;
    public GameObject timeline;

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
      //boxGameEnd.SetActive(false);

        boxAnim1 = GameObject.Find("BlueBox");
        boxAnim2 = GameObject.Find("RedBox");
        boxAnim3 = GameObject.Find("YellowBox");

        LoadLevel(Global.level);
        

        //Provisional
        ShowScoreInfo();
        StrtGame();
            Debug.Log("NIVELLMAX: " + Global.maxLevelPublished);
            Debug.Log("MAXLVLARRIBAT: " + Global.maxLevel);

        soundManager.PlayGameSoundtrack();
    }

    private void Update() {
        if(Input.GetKey("m"))
        {
            PlayerPrefs.SetInt("CinematicaReproducida", 0);
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
        switch (num)
        {
           case 1:

            Debug.Log("PUNTUACIÓMAXIMAAQUESTNIVELL: "+ Global.maxScore);
            Debug.Log("NIVELLACTUAL: "+ num);

            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);

            Global.machine1BoxTime = 40;
            Global.machine2BoxTime = 40;
            Global.machine3BoxTime = 35;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 2:

            Debug.Log("NIVELLACTUAL: "+ num);

            Global.requestBox.Add(3);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 40;
            Global.machine2BoxTime = 30;
            Global.machine3BoxTime = 30;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 3:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            
            Global.machine1BoxTime = 45;
            Global.machine2BoxTime = 30;
            Global.machine3BoxTime = 35;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 4:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 40;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 30;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 4;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 5:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
                       
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 35;
            Global.machine3BoxTime = 40;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 6:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 35;
            Global.machine2BoxTime = 35;
            Global.machine3BoxTime = 35;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;       

            case 7:

            Debug.Log("NIVELLACTUAL: "+ num);
           
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 30;
            Global.machine3BoxTime = 20;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 8:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(1);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 32;
            Global.machine2BoxTime = 28;
            Global.machine3BoxTime = 25;
            Global.machine1accumulatedBoxesLimit = 4;
            Global.machine2accumulatedBoxesLimit = 4;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 9:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 35;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 35;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 10:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 26;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 11:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 26;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 12:

            Debug.Log("NIVELLACTUAL: "+ num);
            //TO DO
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 26;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 13:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            
            Global.machine1BoxTime = 28;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 27
            ;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 14:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 26;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 15:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 25;
            Global.machine3BoxTime = 26;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;
            
            break;

            case 16:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 35;
            Global.machine2BoxTime = 29;
            Global.machine3BoxTime = 32;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 17:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 31;
            Global.machine3BoxTime = 32;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 18:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(2);
            Global.requestBox.Add(3);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(1);
            
            Global.machine1BoxTime = 30;
            Global.machine2BoxTime = 35;
            Global.machine3BoxTime = 32;
            Global.machine1accumulatedBoxesLimit = 4;
            Global.machine2accumulatedBoxesLimit = 4;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 19:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(3);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 32;
            Global.machine2BoxTime = 31;
            Global.machine3BoxTime = 30;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;

            break;

            case 20:

            Debug.Log("NIVELLACTUAL: "+ num);
            
            Global.requestBox.Add(1);
            Global.requestBox.Add(1);
            Global.requestBox.Add(3);
            Global.requestBox.Add(2);
            
            Global.machine1BoxTime = 32;
            Global.machine2BoxTime = 28;
            Global.machine3BoxTime = 25;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 4;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;
            break;

            default:
               break;   
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
        if(Global.level == 1){
            if(PlayerPrefs.GetInt("CinematicaReproducida", 0) == 0){
            StartCoroutine(WaitTimeline());
            }else{
                DesactivarCinematica();
                ShowCamDrag();
            }
        }
        if(Global.level != 1){
            DesactivarCinematica();
        }
    }

    public void PauseGame()
    {
        playerController.cantMove = true;
        machine2.PauseMachine2();
        machine1.PauseMachine1();
        machine3.PauseMachine3();
        isPlaying = false;
        Global.meteorites = false;
    }

    private void unPauseGame()
    {
        playerController.cantMove = false;
        machine2.PlayMachine2();
        machine1.PlayMachine1();
        machine3.PlayMachine3();
        isPlaying = true;
        Global.meteorites = true;
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
            ScoreFinal(); //Suma punts Work in progres

                if(Global.maxScore < Global.score){
                        Global.maxScore = Global.score; 
                        Debug.Log("HAS SUPERAT EL TEU RECORD: "+ Global.maxScore);
                        PlayerPrefs.SetInt("maxScore",Global.maxScore);
                        Global.finalTime = Time.time;
                        PlayerPrefs.SetFloat("totalTime",(PlayerPrefs.GetFloat("totalTime",0) + (Global.finalTime - Global.initialTime)));
                        Global.initialTime = Time.time;
                } 

            ShowLevelCompleted();

                if(Global.maxLevel < Global.level){
                    Global.maxLevel = Global.level;
                    Debug.Log("Max Level POSTWIN: " + Global.maxLevel);

                    if(PlayerPrefs.GetInt("maxLevel", 0) < Global.maxLevel){
                        PlayerPrefs.SetInt("maxLevel", Global.maxLevel);
                    }

                    Global.finalTime = Time.time;
                    PlayerPrefs.SetFloat("totalTime",(PlayerPrefs.GetFloat("totalTime",0) + (Global.finalTime - Global.initialTime)));
                    Global.initialTime = Time.time;
                }

                Global.level ++;
            } else{
                Debug.Log("victoryEPICA");
                ShowGameCompleted();
                Global.finalTime = Time.time;
                PlayerPrefs.SetFloat("totalTime",(PlayerPrefs.GetFloat("totalTime",0) + (Global.finalTime - Global.initialTime)));

                if(Global.maxLevel < Global.level){
                    Global.maxLevel = Global.level;

                    if(PlayerPrefs.GetInt("maxLevel", 0) < Global.maxLevel){
                        PlayerPrefs.SetInt("maxLevel", Global.maxLevel);
                    }
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
        Global.maxLevel = Global.level;
        PlayerPrefs.SetFloat("totalTime",(PlayerPrefs.GetFloat("totalTime",0) + (Global.finalTime - Global.initialTime)));
        PauseGame();
    }

    public void ShowLevelCompleted()
    {
        PauseGame();
        boxLevelSuccess.GetComponent<Animator>().SetInteger("StateBox", 1);
        soundManager.PlayVictorySoundtrack();
        
    }

    public void ShowGameCompleted()
    {
        PauseGame();
        boxGameEnd.GetComponent<Animator>().SetInteger("StateBox", 1);
        Analytics.CustomEvent("Finished Game");
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
        } else
        {
            StartCoroutine(HidePauseMenu());
        }
    }

    public void NextLevel(){
        LoadLevel(Global.level);  
        ShowScoreInfo();
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

    public void ShowCamDrag()
    {
        camDrag.GetComponent<Animator>().SetInteger("StateBox", 1);
        StartCoroutine(HideCamDrag());
    }

    IEnumerator HideCamDrag()
    {
        yield return new WaitForSeconds(4);
        camDrag.GetComponent<Animator>().SetInteger("StateBox", 2);
        unPauseGame();
    }

    public IEnumerator WaitTimeline()
    {
        PauseGame();
        yield return new WaitForSeconds(34.34f);
        fundido.SetActive(false);
        PlayerPrefs.SetInt("CinematicaReproducida", 1);
        unPauseGame();
        StartCoroutine(FundidoActive());
        ShowCamDrag();
    
    }

    public void DesactivarCinematica()
    {
        boxAnim1.SetActive(false);
        boxAnim2.SetActive(false);
        boxAnim3.SetActive(false);
        timeline.SetActive(false);
        fundido.SetActive(false);
    }

    public IEnumerator FundidoActive(){
        SceneManager.LoadScene("PSF");
        yield return new WaitForSeconds(1f);
        fundido.GetComponent<Animator>().SetInteger("Fade", 2);

        
    }
}
