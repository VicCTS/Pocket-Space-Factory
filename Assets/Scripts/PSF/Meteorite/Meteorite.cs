using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float magnitude;
    private Rigidbody rb;
    private GameObject meteoriteRejection;

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
        meteoriteRejection = GameObject.Find("BugMeteoriteDestructor");
    }

    private void Start()
    {
        MeteoriteFall();
    }

    public void MeteoriteFall()
    {
        float forceX = Random.Range(minForceX, maxForceX);
        float forceY = Random.Range(minForceY, maxForceY);
        float forceZ = Random.Range(minForceZ, maxForceZ);

        Vector3 direction = new Vector3(forceX, forceY, forceZ);
        
        rb.AddForce(direction * magnitude);
    }

    private void OnTriggerEnter(Collider rocks)
    {
        if(rocks.tag == "MeteoriteInteraction")
        {
            meteoriteRejection.GetComponent<MeteoriteRejection>().NoAcces();
        }

        if(rocks.tag == "BugMeteoriteDestructor")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider rocks)
    {
        if(rocks.tag == "MeteoriteInteraction")
        {
            meteoriteRejection.GetComponent<MeteoriteRejection>().Acces();
        }
    }
}
