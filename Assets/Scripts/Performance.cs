using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Performance : MonoBehaviour
{
    public Text fpsDisplay;
    public List<GameObject> objOptimizar;
    public static bool rendimiento;

    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        //fpsDisplay.text = fps + " FPS";

        if(fps < 600){
            rendimiento = false;
            for(int i = 0; i < objOptimizar.Count; i++){
                objOptimizar[i].SetActive(false);
            }
        }else {
            rendimiento = true;
            for(int i = 0; i < objOptimizar.Count; i++){
                objOptimizar[i].SetActive(true);
            }
        }

    }
}
