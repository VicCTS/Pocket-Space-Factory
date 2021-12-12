using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaAnim : MonoBehaviour
{
    Animator anim;
    public bool isGrua;

    public int secondsLeft = 5;
    public bool takingAway = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            TimerTake();
            //anim.SetBool("Grua", true);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        takingAway = false;
    }  
}
