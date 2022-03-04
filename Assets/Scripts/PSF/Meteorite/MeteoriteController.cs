using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject parentObject;
    
    //Rango de posiciones en que se generan los meteoritos
    [Header("POSITIONS")]
    public float minPosX;
    public float maxPosX;
    public float minPosZ;
    public float maxPosZ;

    //Tiempos de la generación de meteoritos
    [Header("TIMES")]
    public float initialLapse;
    public float lapse;

    private void Start()
    {      
        InvokeRepeating("MeteoriteGeneration", initialLapse, lapse);
        StartCoroutine("Meteorites");
    }

    private IEnumerator Meteorites()
    {
        yield return new WaitForSeconds(35);
        Global.meteorites = true;
    }

    private void MeteoriteGeneration()
    {
        float posX = Random.Range(minPosX, maxPosX); //Posición aleatoria X
        float posZ = Random.Range(minPosZ, maxPosZ); //Posición aleatoria Z
        
        if (Global.meteorites == true)
        {
            //Tipo de meteorito de forma aleatoria 
            int n = Random.Range(0, rocks.Length);

            //Tipos de meteoritos, posición al generarse, rotación al generarse, dentro de que "Gameobject" se genera
            

            GameObject meteoriteInstantiate = MeteoritePooling.instance.GetPooledObject(n);
            meteoriteInstantiate.SetActive(true);
            meteoriteInstantiate.transform.position = new Vector3(posX, 25, posZ);
            meteoriteInstantiate.transform.rotation = rocks[n].transform.rotation;
            

            
            Debug.Log("Meteorite");          
        }
    }
}
