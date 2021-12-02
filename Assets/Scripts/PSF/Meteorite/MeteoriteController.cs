using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject parentObject;
    
    [Header("POSITIONS")]
    public float minPosX;
    public float maxPosX;
    public float minPosZ;
    public float maxPosZ;

    [Header("TIMES")]
    public float initialLapse;
    public float lapse;

    private void Start()
    {      
        InvokeRepeating("MeteoriteGeneration", initialLapse, lapse);
    }

    private void MeteoriteGeneration()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posZ = Random.Range(minPosZ, maxPosZ);
        
        if (Global.meteorites == true)
        {
            int n = Random.Range(0, rocks.Length);            
            Instantiate(rocks[n], new Vector3(posX, 25, posZ), rocks[n].transform.rotation, parentObject.transform);
            
            Debug.Log("Meteorite");          
        }
    }
}
