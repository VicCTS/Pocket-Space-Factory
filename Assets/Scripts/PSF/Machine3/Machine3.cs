using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine3 : MonoBehaviour
{
    [Header("UI")]
    public GameObject boxesAcc;         //Cajas acumuladas.
    public GameObject timeNextBox;      //Tiempo de aparicion de las cajas.
    public Image timeBar;               //Game Object de la barra que se vacia.
    public GameObject luzEncendidaM3;
    public AudioClip alertaClip;
    public AudioSource alertaSound;
    private bool alertSoundBool = true;

    [Header("Time")]
    public int totalTime;               //Tiempo en segundos con cuenta regresiva para la siguiente caja.
    public float animTime;              //Tiempo que se espera el timer y la caja en aparecer(Poner tiempo necesario para animacion).

    [Header("State")]
    public GameObject box;              //Objeto a instanciar.
    public Transform spawnPosition;     //Punto de aparicion de las cajas.
    public GameObject parentObject;     //GameObject que ser� el padre de todas las cajas para que quede ordenado.
    public bool isWorking;              //Determina si la maquina 2 esta en funcionamiento
    public bool powerUpActived;         //Determina si la maquina 2 esta en funcionamiento en los Power Ups    
    public int accumulatedBoxes;        //Cajas acumuladas en ESTE MOMENTO;
    public int accumulatedBoxesLimt;    //Limite de cajas que puedo cumular en la maquina.

    private float nextTime;             //Variable auxiliar.
    private float pauseTime;            //Sirve para regular el temporizador por segundos.
    private bool wait;                  //Sirve para controlar el timer segun el tiempo de animacion.
    public bool waitCoroutine = true;
    public bool boxSpawned;
    private GameManager gameManager; 
    public Animator anim; 
    private float timePercent           //Variable que realiza una funcion. Convierte el tiempo que queda en un porcentaje.
    {
        get {return (float) totalTime / Global.machine3BoxTime;}
    }

    
     private void Awake() 
    {
        gameManager = GetComponent<GameManager>();
        isWorking = false;  
        powerUpActived = false;   
        luzEncendidaM3.SetActive(false); 
    }

    public void StartMachine3() 
    {
        ConfigureMachine3();
        totalTime = Global.machine3BoxTime;
        accumulatedBoxes = 0;
        accumulatedBoxesLimt = Global.machine3accumulatedBoxesLimit;
        UpdateTextInfo();
        PlayMachine3();
        PlayMachine3PowerUp();

    }

    public void ConfigureMachine3()
    {
        nextTime = 0;     
        pauseTime = 1f;   //Interval time (1 = 1 second)
        wait = false;     // Para la animacion
        boxSpawned = false; 
    }

    public void PauseMachine3()
    {
        isWorking = false;
    }

    public void PlayMachine3()
    {
        isWorking = true;
    }
    
    public void PlayMachine3PowerUp()
    {
        powerUpActived = false;

    }
    
    public void PauseMachine3PowerUp()
    {
        powerUpActived = true;

    }

    public void UpdateTextInfo()
    { 
       boxesAcc.GetComponent<Text>().text  = accumulatedBoxes.ToString() + "/" + accumulatedBoxesLimt.ToString();
       timeNextBox.GetComponent<Text>().text  = totalTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedBoxesLimt = Global.machine3accumulatedBoxesLimit;

        if (isWorking == true)
        {    
            if(powerUpActived == false)
            {
                if (Time.time > nextTime)
                {
                    // Define el proximo accion desntro de 1 segundo
                    nextTime = Time.time + pauseTime;

                    //ACTION
                    ActionMachine3();
                    Animation();
                }
            }

            if(accumulatedBoxes == accumulatedBoxesLimt-1)
            {
                AlertaRoja();
            }
            else
            {
                alertSoundBool = true;
            }
        }  
    }

    private void ActionMachine3()
    {
        if (accumulatedBoxes < Global.machine3accumulatedBoxesLimit)
        {
            totalTime--;
            if (totalTime < 0)
            {
                totalTime = 0;

                StartCoroutine(WaitAnim());
                if (wait == true)
                {
                    SpawnBox();
                    totalTime = Global.machine3BoxTime;
                }
            }
            wait = false;
            UpdateTextInfo();
            timeBar.fillAmount = timePercent;
        }
        else
        {
            totalTime = Global.machine3BoxTime;
            gameManager.ShowGameOver();
            gameManager.PauseGame();
        }
    }

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(4);
        wait = true;
        anim.SetBool("GruaOn", false);
        yield return new WaitForSeconds(4);
        boxSpawned = true;
    }

    public void SpawnBox()
    {
        if(accumulatedBoxes <  Global.machine2accumulatedBoxesLimit)
        {
            Instantiate(box, spawnPosition.transform.position, Quaternion.identity, parentObject.transform);
        }
    }

    public void Animation()
    {
        if(accumulatedBoxes <  Global.machine2accumulatedBoxesLimit)
        {
            if(totalTime == 0) //
            {
                anim.SetBool("GruaOn", true);              
            }

            if(boxSpawned == true)
            {
                anim.SetTrigger("TakeOff");
                boxSpawned = false;
            }
        }
    }

    private void AlertaRoja()
    {
        if(waitCoroutine == true)
        {
          waitCoroutine = false;
          StartCoroutine(LuzAlerta());  
        }
        
        
        if(Global.canSFXPlay == true && alertSoundBool)
        {
           alertaSound.PlayOneShot(alertaClip, 1);
           alertSoundBool = false;
        }
        
    }

    IEnumerator LuzAlerta()
    {
        luzEncendidaM3.SetActive(true);
        yield return new WaitForSeconds(1);
        luzEncendidaM3.SetActive(false);
        yield return new WaitForSeconds(1);
        waitCoroutine = true;
    }
}
