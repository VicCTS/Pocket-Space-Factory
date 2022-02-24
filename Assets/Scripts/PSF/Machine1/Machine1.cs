using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine1 : MonoBehaviour
{
    [Header("UI")]
    public GameObject boxesAcc;         //Cajas acumuladas.
    public GameObject timeNextBox;      //Tiempo de aparicion de las cajas.
    public Image timeBar;               //Game Object de la barra que se vacia.
    public GameObject luzEncendidaM1;
    public AudioClip alertaClip;
    public AudioSource alertaSound;
    private bool alertSoundBool = true;

    [Header("Time")]
    public float totalTime;               //Tiempo en segundos con cuenta regresiva para la siguiente caja.
    public float animTime;              //Tiempo que se espera el timer y la caja en aparecer(Poner tiempo necesario para animacion).

    [Header("State")]
    public GameObject box;              //Objeto a instanciar.
    public Transform spawnPosition;     //Punto de aparicion de las cajas.
    public GameObject parentObject;     //GameObject que ser� el padre de todas las cajas para que quede ordenado.
    public bool isWorking;   
    public bool powerUpActived;           //Determina si la maquina 1 esta en funcionamiento
    public int accumulatedBoxes;        //Cajas acumuladas en ESTE MOMENTO;
    public int accumulatedBoxesLimt;    //Limite de cajas que puedo cumular en la maquina.

    private float nextTime;             //Variable auxiliar.
    private float pauseTime;            //Sirve para regular el temporizador por segundos.
    private bool wait;                  //Sirve para controlar el timer segun el tiempo de animacion.
    public bool waitCoroutine = true;                 //Sirve para controlar el timer segun el tiempo de animacion.
    private GameManager gameManager; 
    private float timePercent           //Variable que realiza una funcion. Convierte el tiempo que queda en un porcentaje.
    {
        get {return (float) totalTime / Global.machine1BoxTime;}
    }

     private void Awake() 
    {
        gameManager = GetComponent<GameManager>();
        isWorking = false;  
        Global.machine1BoxTime = 6;  
        powerUpActived = false;
        luzEncendidaM1.SetActive(false);
    }

    public void StartMachine1() 
    {
        ConfigureMachine1();
        totalTime = Global.machine1BoxFirstTime;
        accumulatedBoxes = 0;
        accumulatedBoxesLimt = Global.machine1accumulatedBoxesLimit;
        UpdateTextInfo();
        PlayMachine1();
        PlayMachine1PowerUp();
    }

    public void ConfigureMachine1()
    {
        nextTime = 0;     
        pauseTime = 1f;   //Interval time (1 = 1 second)
        wait = false;     // Para la animacion
    }

    public void PauseMachine1()
    {
        isWorking = false;
    }

    public void PlayMachine1()
    {
        isWorking = true;
    }

    public void PlayMachine1PowerUp()
    {
        powerUpActived = false;
    }

     public void PauseMachine1PowerUp()
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
        accumulatedBoxesLimt = Global.machine1accumulatedBoxesLimit;

        if (isWorking == true)
        {   
            if(powerUpActived == false)
            { 
                if (Time.time > nextTime)
                {
                    // Define el proximo accion desntro de 1 segundo
                    nextTime = Time.time + pauseTime;

                    //ACTION
                    ActionMachine1();
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

    private void ActionMachine1()
    {
        if (accumulatedBoxes < Global.machine1accumulatedBoxesLimit) 
        {
            totalTime--;
            if (totalTime < 0)
            {
                totalTime = 0;

                /*  StartCoroutine(WaitAnim());
                 if (wait == true)
                 {*/
                SpawnBox();
                totalTime = Global.machine1BoxTime;

            }
            wait = false;
            UpdateTextInfo();
            timeBar.fillAmount = timePercent;
        } else
        {
            totalTime = Global.machine1BoxTime;
            gameManager.ShowGameOver();
            gameManager.PauseGame();
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
        luzEncendidaM1.SetActive(true);
        yield return new WaitForSeconds(1);
        luzEncendidaM1.SetActive(false);
        yield return new WaitForSeconds(1);
        waitCoroutine = true;
    }

    public void SpawnBox()
    {
        if(accumulatedBoxes <  Global.machine1accumulatedBoxesLimit)
        {
            Instantiate(box, spawnPosition.transform.position, Quaternion.identity, parentObject.transform);
        }
    }
}
