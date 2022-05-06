using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
    public GameObject BGShop;
    public PlayerController playerController;
    public bool ShopOn = false;

    
    public GameObject PU1;
    public GameObject PU2;
    public GameObject PU3;
    public GameObject PU4;
    public GameObject PU5;
    public GameObject PU6;
    public Image BG;

    public int IdPowUp;
    private int valueButt;
    private int a;
    public bool havePU = false;

    void Update (){

    }
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        PU1.GetComponent<Image>();
        PU2.GetComponent<Image>();
        PU3.GetComponent<Image>();
        PU4.GetComponent<Image>();
        PU5.GetComponent<Image>();
        PU6.GetComponent<Image>();


        PU1.gameObject.SetActive (false);
        PU2.gameObject.SetActive (false);
        PU3.gameObject.SetActive (false);
        PU4.gameObject.SetActive (false);
        PU5.gameObject.SetActive (false);
        PU6.gameObject.SetActive (false);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerInteractionZone")
        {
            BGShop.GetComponent<Animator>().SetInteger("StateBox", 1);
            playerController.cantMove = true;
            ShopOn = true;
            BuyOnShop(valueButt);
        }
    }

    public void HideBGShop()
    {
        BGShop.GetComponent<Animator>().SetInteger("StateBox", 2);
        playerController.cantMove = false;
        ShopOn = false;
    }


    public void BuyOnShop(int valueButt){

                Debug.Log("Abans Switch: " +  valueButt);

        if(havePU == false){
        switch (valueButt)
        {
        case 1:
            if(Global.score >= Global.priceSpeedBoost ){
            //Compra el Boost
                Global.score = Global.score - Global.priceSpeedBoost;
                IdPowUp = 1;
                BG.color = new Color32(225,225,225,225);
                PU1.SetActive(true);
                havePU = true;
            }else{
            //No te pous diners
                Debug.Log("No Money ");

            }
        break;

        case 2:
            if(Global.score >= Global.priceStopMachineBoost ){
                Global.score = Global.score - Global.priceStopMachineBoost;
                IdPowUp = 2;
                BG.color = new Color32(225,225,225,225);
                PU2.SetActive(true);
                havePU = true;

            }else{
                Debug.Log("No Money ");
                
            }
        break;

        case 3:
            if(Global.score >= Global.priceClearMeteoBoost){
                Global.score = Global.score - Global.priceClearMeteoBoost;
                IdPowUp = 3;
                BG.color = new Color32(225,225,225,225);
                PU3.SetActive(true);
                havePU = true;

            }else{
                Debug.Log("No Money ");

            }
        break;

        case 4:
            if(Global.score >= Global.priceCapsuleBoost){
                Global.score = Global.score - Global.priceCapsuleBoost;
                IdPowUp = 4;
                BG.color = new Color32(225,225,225,225);
                PU4.SetActive(true);
                havePU = true;

            }else{
                Debug.Log("No Money ");

            }
        break;

        case 6:
            if(Global.score >= Global.priceMaxBoxsBoost ){
                Global.score = Global.score - Global.priceMaxBoxsBoost;
                IdPowUp = 6;
                BG.color = new Color32(225,225,225,225);
                PU6.SetActive(true);

                havePU = true;

            }else{
                Debug.Log("No Money ");

            }
        break;


        default:
            Debug.Log("Welkcome to Shoop");
            break;
        }
    }
        
    }

    public void GetIdPowerUp(int IdPowrUpImg){
         IdPowrUpImg = IdPowUp;
    }

    public void NoPU()
    {
        havePU=false;
    }
}
