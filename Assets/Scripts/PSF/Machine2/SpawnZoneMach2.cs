using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneMach2 : MonoBehaviour
{
    private Machine2 machine2;

    // Start is called before the first frame update
    private void Awake() 
    {
        machine2 = GameObject.Find("GameManager").GetComponent<Machine2>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box2")
        {
            Debug.Log("Caja");
            machine2.accumulatedBoxes++;
            machine2.UpdateTextInfo();
        }
    }

        public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Box2")
        {
            Debug.Log("Caja");
            machine2.accumulatedBoxes--;
            machine2.UpdateTextInfo();
        }
    }

}
