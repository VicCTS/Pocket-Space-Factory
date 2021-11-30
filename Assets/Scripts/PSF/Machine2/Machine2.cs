using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine2 : MonoBehaviour
{
    [Header("UI")]
    public GameObject boxesAcc;         //Cajas acumuladas.
    public GameObject timeNextBox;      //Tiempo de aparicion de las cajas.
    public Image timeBar;               //Game Object de la barra que se vacia.

    [Header("Time")]
    public int totalTime;               //Tiempo en segundos con cuenta regresiva para la siguiente caja.
    public float animTime = 4;              //Tiempo que se espera el timer y la caja en aparecer(Poner tiempo necesario para animacion).

    [Header("State")]
    public GameObject box;              //Objeto a instanciar.
    public Transform spawnPosition;     //Punto de aparicion de las cajas.
    public GameObject parentObject;     //GameObject que ser� el padre de todas las cajas para que quede ordenado.
    public bool isWorking;              //Determina si la maquina 2 esta en funcionamiento
    public int accumulatedBoxes;        //Cajas acumuladas en ESTE MOMENTO;
    public int accumulatedBoxesLimt;    //Limite de cajas que puedo cumular en la maquina.

    private float nextTime;             //Variable auxiliar.
    private float pauseTime;            //Sirve para regular el temporizador por segundos.
    public bool wait;                  //Sirve para controlar el timer segun el tiempo de animacion.
    public bool boxSpawned;
    private GameManager gameManager;
    public Animator anim; 
    private float timePercent           //Variable que realiza una funcion. Convierte el tiempo que queda en un porcentaje.
    {
        get {return (float) totalTime / Global.machine2BoxTime;}
    }

     private void Awake() 
    {
        gameManager = GetComponent<GameManager>();
        isWorking = false;    
    }

    public void StartMachine2() 
    {
        ConfigureMachine2();
        totalTime = Global.machine2BoxTime;
        accumulatedBoxes = 0;
        accumulatedBoxesLimt = Global.machine2accumulatedBoxesLimit;
        UpdateTextInfo();
        PlayMachine2();
    }

    public void ConfigureMachine2()
    {
        nextTime = 0;     
        pauseTime = 1f;          //Interval time (1 = 1 second)
        wait = false;            // Para la animacion
        boxSpawned = false; 
    }

    public void PauseMachine2()
    {
        isWorking = false;
    }

    public void PlayMachine2()
    {
        isWorking = true;
    }

    public void UpdateTextInfo()
    { 
       boxesAcc.GetComponent<Text>().text  = accumulatedBoxes.ToString();
       timeNextBox.GetComponent<Text>().text  = totalTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking == true)
        {    
            if (Time.time > nextTime)
            {
                // Define el proximo accion desntro de 1 segundo
                nextTime = Time.time + pauseTime;

                //ACTION
                ActionMachine2();
                Animation();
            }
        }  
    }

    private void ActionMachine2()
    {
        if(accumulatedBoxes <  Global.machine2accumulatedBoxesLimit)
        {
            if(totalTime >= 0)
            {
                totalTime--;
            }
            
            if (totalTime < 0)
            {      
                totalTime = 0;
            
                StartCoroutine(WaitAnim());
                if (wait == true)
                {
                    SpawnBox();
                    totalTime = Global.machine2BoxTime;
                }
            }
            wait = false;
            UpdateTextInfo();
            timeBar.fillAmount = timePercent;
        }
        else
        {
            totalTime = Global.machine2BoxTime;
            gameManager.ShowGameOver();
            gameManager.PauseGame();
        }      
    }

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(2);
        wait = true;
        anim.SetBool("Landing", false);
        yield return new WaitForSeconds(2);
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
                anim.SetBool("Landing", true);              
            }

            if(boxSpawned == true)
            {
                anim.SetTrigger("Takeoff");
                boxSpawned = false;
            }
        }
    }
}
