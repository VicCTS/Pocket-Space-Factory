using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public float waitTime;
    public float waitTimeFadeOut;
    public string sceneDestinationName;
    public Animator fade;
     
    void Start()
    {
        fade.SetInteger("Fade", 1);
        StartCoroutine(OtherScene());
    }

    IEnumerator OtherScene()
    {
        yield return new WaitForSeconds(waitTime);
        fade.SetInteger("Fade", 2);        
        if (sceneDestinationName !="")
        {
          yield return new WaitForSeconds(waitTimeFadeOut);
          SceneManager.LoadScene(sceneDestinationName);
        }
    }
}
