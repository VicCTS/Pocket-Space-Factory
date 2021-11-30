using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZoneMach1 : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Awake() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("CajaAzul");
        if(other.tag == "Box3")
        {
            Debug.Log("CajaAzul");
            if(gameManager.actualBoxType==3)
            {
                Debug.Log("CajaAzul");
                Global.score += Global.machine1Score;
                gameManager.ShowScoreInfo();
                gameManager.UpdateBox();

            }
            
        }
    }
}
