using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneMach1 : MonoBehaviour
{
    private Machine1 machine1;

    // Start is called before the first frame update
    private void Awake() 
    {
        machine1 = GameObject.Find("GameManager").GetComponent<Machine1>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Box3")
        {
            Debug.Log("CajaAzul");
            machine1.accumulatedBoxes++;
            machine1.UpdateTextInfo();
        }
    }

        public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Box3")
        {
            Debug.Log("CajaAzul");
            machine1.accumulatedBoxes--;
            machine1.UpdateTextInfo();
        }
    }
}
