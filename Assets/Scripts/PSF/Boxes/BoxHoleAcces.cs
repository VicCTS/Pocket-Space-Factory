using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHoleAcces : MonoBehaviour
{
    public void Correct()
    {
        Debug.Log("CORRECT");

        gameObject.transform.Translate(0, -10, 0);
        StartCoroutine("Translation");
    }
    
    private IEnumerator Translation()
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.Translate(0, 10, 0);
    }
}
