using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZoneMach3 : MonoBehaviour
{
     private GameManager gameManager;

    // Start is called before the first frame update
    private void Awake() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box1")
        {
            if(gameManager.actualBoxType==3)
            {
                Debug.Log("CajaRoja");
                Global.score += Global.machine3Score;
                gameManager.ShowScoreInfo();
                gameManager.UpdateBox();
            }
            
        }
    }


}
