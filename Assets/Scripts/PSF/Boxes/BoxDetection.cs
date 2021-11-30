using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    public float destructionTime;

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxDestroyer")
        {
            StartCoroutine("BoxDestruction");
        }
    }

    private IEnumerator BoxDestruction()
    {
        yield return new WaitForSeconds(destructionTime);
        Destroy(gameObject);
    }
}

