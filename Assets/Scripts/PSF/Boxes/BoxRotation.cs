using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{

    void Update()
    {
        if(Performance.rendimiento){
            transform.Rotate(new Vector3(0f, 180f, 0f) * Time.deltaTime);
        }
    }
}
