using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRejection : MonoBehaviour
{
    public float maxForce;
    public float minForce;
    public Vector3 forceDirectionVector;
    public int boxType;
    
    private GameObject rejectionZone;
    private GameManager gameManager;

    private void Awake()
    {
        rejectionZone = GameObject.Find("BoxRejection");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision box)
    {
        if (box.gameObject.tag == "BoxRejection")
        {
            Debug.Log(gameManager.actualBoxType);
            if (gameManager.actualBoxType == boxType)
            {
                Correct();
            } else
            {
                Incorrect();
            }
        }
    }

    private void Incorrect()
    {
        Debug.Log("INCORRECT");
        float forceMagnitude = Random.Range(minForce, maxForce);
        Vector3 force = Vector3.Normalize(forceDirectionVector) * forceMagnitude;

        gameObject.GetComponent<Rigidbody>().AddForce(force);
    }

    private void Correct()
    {
        rejectionZone.GetComponent<BoxHoleAcces>().Correct();
    }
}
