using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneMach3 : MonoBehaviour
{
    private Machine3 machine3;

    // Start is called before the first frame update
    private void Awake() 
    {
        machine3 = GameObject.Find("GameManager").GetComponent<Machine3>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box1")
        {
            Debug.Log("Caja");
            machine3.accumulatedBoxes++;
            machine3.UpdateTextInfo();
        }
    }

        public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Box1")
        {
            Debug.Log("Caja");
            machine3.accumulatedBoxes--;
            machine3.UpdateTextInfo();
        }
    }

}
