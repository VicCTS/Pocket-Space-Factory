using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZoneMach2 : MonoBehaviour
{
     private GameManager gameManager;

    // Start is called before the first frame update
    private void Awake() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box2")
        {
            if(gameManager.actualBoxType==2)
            {
                Global.score += Global.machine2Score;
                gameManager.ShowScoreInfo();
                gameManager.UpdateBox();
                gameManager.GetComponent<BoxesNeededUI>().deliveredBoxes++;
                gameManager.GetComponent<BoxesNeededUI>().SlideRight();
                
            }
            
        }
    }


}
