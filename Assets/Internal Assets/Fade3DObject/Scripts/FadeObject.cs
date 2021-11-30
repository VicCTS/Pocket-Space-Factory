using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{  
    public GameObject obj;
    public bool mustToDestroy;  // If want to destroy
    public float timeToFadeOut; // +timeToFade = Faster fade out
    public float timeToFadeIn;  // +timeToFade = Faster fade in
    
    private bool fadeInOut;
    private bool canFade;
    private Color alphaColor;
    private Color originalColor;
     
    public void Start()
    {
        canFade = false;
        
        var material = GetComponent<Renderer>().material;
        alphaColor = new Color(material.color.r,material.color.g,material.color.b,0);
        originalColor = material.color;
    }
         
    public void Update()
    {
        if (fadeInOut == true && canFade == true)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.Lerp(obj.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFadeOut * Time.deltaTime);
                        
            if (obj.GetComponent<MeshRenderer>().material.color.a < 0.01f)
            {
                canFade = false;
                if (mustToDestroy == true)
                {
                    Destroy(gameObject);
                }
                
            }
        }

        if (fadeInOut == false && canFade == true)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.Lerp(obj.GetComponent<MeshRenderer>().material.color, originalColor, timeToFadeIn * Time.deltaTime);
            Debug.Log("alpha: " + obj.GetComponent<MeshRenderer>().material.color.a);

            if (obj.GetComponent<MeshRenderer>().material.color.a > 0.99f)
            {
                canFade = false;
            }
        }        
    }

    public void StartFadeOut()
    {
        fadeInOut = true;
        canFade = true;
    }

    public void StartFadeIn()
    {
        fadeInOut = false;
        canFade = true;
    }
}
