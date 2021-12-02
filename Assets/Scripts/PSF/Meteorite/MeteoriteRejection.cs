using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteRejection : MonoBehaviour
{
    public bool acces;
    private GameObject meteoriteRejection;

    private void Awake()
    {
        meteoriteRejection = GameObject.Find("MeteoriteRejection");
    }

    private void Start()
    {
        acces = true;
    }

    public void NoAcces()
    {
        gameObject.transform.Translate(0, 8, 0);
    }

    public void Acces()
    {
        gameObject.transform.Translate(0, -8, 0);
    }
}
