using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float magnitude;
    public float rejMagnitude;

    private float wallY;
    private Rigidbody rb;
    private GameObject meteoriteRejection;
    private GameObject wall;

    //Rango de fuerzas aleatorias de los meteoritos al generarse
    [Header("DIRECTION FORCES")]
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;
    public float minForceZ;
    public float maxForceZ;

    //Rango de fuerzas aleatorias del rechazo de los meteoritos
    [Header("REJECTION FORCES")]
    public float minRejForceX;
    public float maxRejForceX;
    public float minRejForceY;
    public float maxRejForceY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meteoriteRejection = GameObject.Find("MeteoriteRejection");
        wall = GameObject.Find("BoxHoleWall_1");
    }

    private void Start()
    {
        wallY = wall.transform.position.y;
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
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider rocks)
    {
        if(rocks.tag == "MeteoriteDetector")
        {
            Acces();
        }
    }

    //Acción del meteorito al no poder entrar
    private void OnCollisionStay(Collision rocks)
    {
        if(rocks.gameObject.tag == "MeteoriteRejection")
        {
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y * -Time.deltaTime, wall.transform.position.z); //El muro se mueve
            transform.Rotate(new Vector3(0, 180f, 0) * Time.deltaTime);            

            StartCoroutine("RejectionTime");
        }
    }

    //Tiempo en que el meteorito sale rechazado
    private IEnumerator RejectionTime()
    {
        yield return new WaitForSeconds(1);
        RejectionMeteorite();
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

    //Fuerza aleatoria del meteorito para salir rechazado
    private void RejectionMeteorite()
    {
        float rejForceX = Random.Range(minRejForceX, maxRejForceX);  //Fuerza aleatoria del Vector X
        float rejForceY = Random.Range(minRejForceY, maxRejForceY);  //Fuerza aleatoria del Vector Y
        
        Vector3 rejector = new Vector3(rejForceX, rejForceY, 0); //Dirección final de la fuerza
        
        rb.AddForce(rejector * rejMagnitude); //Fuerza Inflingida

        StartCoroutine("WallPosition");
    }

    //El muro vuelve a su posición original
    private IEnumerator WallPosition()
    {
        yield return new WaitForSeconds(1);

        wall.transform.position = new Vector3(wall.transform.position.x, wallY, wall.transform.position.z);
    }
}
