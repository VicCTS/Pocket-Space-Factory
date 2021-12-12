using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float magnitude;
    private Rigidbody rb;
    private GameObject meteoriteRejection;
    private GameObject meteoriteBug;

    //Rango de fuerzas aleatorias de los tres vectores
    [Header("DIRECTION FORCES")]
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;
    public float minForceZ;
    public float maxForceZ;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meteoriteRejection = GameObject.Find("MeteoriteRejection");
    }

    private void Start()
    {
        MeteoriteFall();
    }

    //Se genera una fuerza aleatoria al instante de generarse
    public void MeteoriteFall()
    {
        float forceX = Random.Range(minForceX, maxForceX);  //Fuerza aleatoria del Vector X
        float forceY = Random.Range(minForceY, maxForceY);  //Fuerza aleatoria del Vector Y
        float forceZ = Random.Range(minForceZ, maxForceZ);  //Fuerza aleatoria del Vector Z

        Vector3 direction = new Vector3(forceX, forceY, forceZ); //Dirección final de la fuerza
        
        rb.AddForce(direction * magnitude); //Fuerza inflingida
    }

    private void OnTriggerEnter(Collider rocks)
    {
        if(rocks.tag == "MeteoriteDetector")
        {
            NoAcces();
        }

        if(rocks.tag == "BugMeteoriteDestructor")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider rocks)
    {
        if(rocks.tag == "MeteoriteDetector")
        {
            Acces();
        }
    }

    //Rotación del meteorito al no poder entrar
    private void OnCollisionStay(Collision rocks)
    {
        if(rocks.gameObject.tag == "MeteoriteRejection")
        {
            transform.Rotate(new Vector3(180f, 180f, 180f) * Time.deltaTime);
            
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    //Se bloquea el acceso al agujero
    private void NoAcces()
    {
        meteoriteRejection.transform.Translate(0, 400 * Time.deltaTime, 0);
    }

    //Se desbloquea el acceso al agujero
    private void Acces()
    {
        meteoriteRejection.transform.Translate(0, -400 * Time.deltaTime, 0);
    }
}
