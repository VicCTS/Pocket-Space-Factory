using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("Wait");
    }

    


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(21);
        anim.SetBool("Wait", true);
        float waitTime = Global.machine1BoxTime - 21;
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Wait",false);
        StartCoroutine("Wait");
    }
}
