using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio3DCanPlay : MonoBehaviour
{
    public GameObject[] sFXObjects;
    // Start is called before the first frame update
    void Start()
    {
        if(Global.canSFXPlay == false)
        {
            foreach (GameObject sfx in sFXObjects)
            {
                sfx.SetActive(false);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
