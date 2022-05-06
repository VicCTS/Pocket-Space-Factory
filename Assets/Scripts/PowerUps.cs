using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public PlayerController playerController;
    public ShopManager shopManager;
    public GameManager gameManager;
    /*private Machine2 machine2;
    private Machine1 machine1;
    private Machine3 machine3;*/
    public Image timeImage;
    public GameObject timeParent;

    public GameObject MetExplosion;
    //crear una lista donde almacenar las particulas
    List <GameObject> particles = new List <GameObject>();

    

    [Header("Time")]
    public float totalTimePause;
    public float maxTimePause;
    public float speedTime;
    public float maxSpeedTime;
    private float nextTime;            
    private float pauseTime;
    // Start is called before the first frame update

    private bool powerUpMachinesActived=false;
    private bool powerUpSpeedActived=false;
    private bool powerUpDubelMoney=false;
    private float x2Time ;
    private float maxx2Time;
   


    void Start()
    {
        x2Time = 20f;
        maxx2Time = x2Time;
        pauseTime=1f;
        nextTime = 0;
        totalTimePause=10;
        speedTime=7;
        maxTimePause = totalTimePause;
        maxSpeedTime = speedTime;
        timeImage.GetComponent<Image>();
        
    }

    private void Awake() 
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        shopManager = GameObject.Find("ShopPlatform").GetComponent<ShopManager>();
        gameManager = GetComponent<GameManager>();
        timeParent.SetActive(false);

        //machine2 = GameObject.Find("machine2").GetComponent<Machine2>();
    }
    
    void Update()
    {

        
            if (Time.time > nextTime)
            {
                // Define el proximo accion desntro de 1 segundo
                //nextTime = Time.time + pauseTime;

                //ACTION
                if(powerUpSpeedActived == true)
                { 
                ActionPowerUpSpeed();
                }else if(powerUpMachinesActived == true)
                {
                    ActionPowerUpMachines();                
                }else if(powerUpDubelMoney == true){
                    TimeMoney();
                }
        }

        
    }

    private void ActionPowerUpMachines()
    {
        if(gameManager.isPlaying == true)
        {
            
            if(totalTimePause >= 0)
            {
                totalTimePause -= Time.deltaTime;
                

            }
            
            timeImage.fillAmount = (totalTimePause /  maxTimePause);

            
            if (totalTimePause < 0)
            {      
                totalTimePause = 0;
                gameManager.machine2.PlayMachine2PowerUp();
                gameManager.machine1.PlayMachine1PowerUp();
                gameManager.machine3.PlayMachine3PowerUp();
                powerUpMachinesActived=false;
                totalTimePause = 10;
                shopmanager.PU2.SetActive(false);
                shopManager.BG.color = new Color32(77,77,77,225);

            }

        }
    }

    private void ActionPowerUpSpeed()
    {
        if(gameManager.isPlaying == true)
        {
            
            if(speedTime >= 0)
            {
                speedTime -= Time.deltaTime;
                

            }
            timeImage.fillAmount = (speedTime /  maxSpeedTime);
            
            if (speedTime < 0)
            {
                speedTime=0;
                SpeedDown();
                speedTime=maxSpeedTime;
            }

        }
    }

    public void SpeedBoost()
    {
        SpeedUp();
        powerUpSpeedActived=true;
    }
    
    public void StopMachines()
    {
        gameManager.machine1.PauseMachine1PowerUp();
        gameManager.machine2.PauseMachine2PowerUp();
        gameManager.machine3.PauseMachine3PowerUp();


        powerUpMachinesActived=true;
        
    }

    public void SpeedUp()
    {
        playerController.speed = 9;
    }
    public void SpeedDown()
    {
        playerController.speed = 6;
        powerUpSpeedActived=false;
        shopmanager.PU1.SetActive(false);
        shopManager.BG.color = new Color32(77,77,77,225);

    }

    IEnumerator RestartMachines()
    {
        
        yield return new WaitForSeconds(10);
        
        //machine1.PauseMachine2PowerUp();
        //machine3.PauseMachine2PowerUp();
    }


    public void DestroyObjects()
    {
        //crear un array de game objects y lo llena con los objects del tag que queremos buscar
        GameObject[] met = GameObject.FindGameObjectsWithTag("Meteorite");
        //crea un loop
        foreach(GameObject target in met)
        {
            //por cada objeto que encuentra en este loop instancia las particulas
            GameObject particle = Instantiate (MetExplosion, target.transform.position, target.transform.rotation);
            //despues los añade a la lista que hemos creado
            particles.Add(particle);
            //por ultimo se destruyen los meteoritos
            GameObject.Destroy (target);
        }
        //llamar a la corutina
        StartCoroutine ("DestroyMet");
        shopManager.BG.color = new Color32(77,77,77,225);

    }   

    IEnumerator DestroyMet()
    {
        //esperar dos segundos antes de destruir las particulas
        yield return new WaitForSeconds(2f);
        //despues de esos dos segundos crea un array temporal que añada los objetos en la lista
        var temporalArray = particles.ToArray();
        //y se destruyen esos objetos con un loop
        foreach(GameObject target in temporalArray)
        {
            Destroy(target);
        }
        //despues de que se destruyan las particulas destruimos la lista para que este vacia y volver a llenar en el futuro y no de problemas
        particles.Clear();
    }


    public void DubelMoney(){
        Global.machine1Score = Global.machine1Score * 2;
        Global.machine2Score = Global.machine2Score * 2;
        Global.machine3Score = Global.machine3Score * 2;
        powerUpDubelMoney = true;
    }

    public void TimeMoney(){
        if(gameManager.isPlaying == true)
        {
            
            if(x2Time >= 0)
            {
                x2Time -= Time.deltaTime;
                

            }
            timeImage.fillAmount = (x2Time /  maxx2Time);
            
            if (x2Time < 0)
            {
                x2Time=0;
                SingleMoney();
                shopmanager.PU4.SetActive(false);

                x2Time=maxx2Time;
            }

        }
    }

    public void MoreBoxes()
    {
        Global.machine1accumulatedBoxesLimit++;
        Global.machine2accumulatedBoxesLimit++;
        Global.machine3accumulatedBoxesLimit++;
        shopmanager.PU6.SetActive(false);

        shopManager.BG.color = new Color32(77,77,77,225);

    }
        


    public void SingleMoney(){
        Global.machine1Score = Global.machine1Score / 2;
        Global.machine2Score = Global.machine2Score / 2;
        Global.machine3Score = Global.machine3Score / 2;
        powerUpDubelMoney = false;
        shopManager.BG.color = new Color32(77,77,77,225);

    }


    public ShopManager shopmanager;

    public void ImgButtPowerUp(){
        if(shopmanager.ShopOn == false && shopmanager.havePU == true){

            switch (shopmanager.IdPowUp){
                case 1:
                    SpeedBoost();
                    shopmanager.NoPU();
                    timeParent.SetActive(true);


                    
                break;
                case 2:
                    StopMachines();
                    shopmanager.NoPU();
                    timeParent.SetActive(true);


                break;
                case 3:
                    DestroyObjects();
                    shopmanager.NoPU();
                    shopmanager.PU3.SetActive(false);


                break;
                case 4:
                    DubelMoney();
                    shopmanager.NoPU();
                    timeParent.SetActive(true);
                break;
                case 6:

                    shopmanager.NoPU();
                    shopmanager.PU6.SetActive(false);
                    MoreBoxes();
                   

                break;

                default:
                
                shopManager.BG.color = new Color32(77,77,77,225);

                break;
        

            }
        }
    }



    


}
