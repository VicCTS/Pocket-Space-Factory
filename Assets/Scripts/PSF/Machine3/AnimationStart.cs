using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    Animator anim;
    public bool isTouching;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box1")
        {
            anim.SetTrigger("AnimMa3");
            Debug.Log("Te inicio la animacion manin");
        }
    }
}
