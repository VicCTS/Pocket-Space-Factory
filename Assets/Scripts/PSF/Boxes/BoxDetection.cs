using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    public float destructionTime;

    public ParticleSystem coins;

    private void Awake()
    {   
        coins = GameObject.Find("Coins").GetComponent<ParticleSystem>();
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
        coins.Play();
        yield return new WaitForSeconds(destructionTime);
        Destroy(gameObject);
    }
}

