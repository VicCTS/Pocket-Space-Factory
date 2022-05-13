using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineInput : MonoBehaviour
{
    [SerializeField]private CinemachineFreeLook cinemachineVirtualCamera;
    

    void Awake()
    {
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
        if(brain== null)
        {
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }
        cinemachineVirtualCamera = GameObject.FindObjectOfType<CinemachineFreeLook>();
        CinemachineCore.GetInputAxis = GetAxisCustom;

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            if (Input.GetMouseButton(0)){
                return UnityEngine.Input.GetAxis("Mouse X");
            } else{
                return 0;
            }
            /*#if UNITY_ANDROID
            if (Input.GetTouch(0)){
                return UnityEngine.Input.GetAxis("Mouse X");
            } else{
                return 0;
            }
            #endif*/
        }
        else if (axisName == "Mouse Y"){
            if (Input.GetMouseButton(0)){
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else{
                return 0;
            }
            /*#if UNITY_ANDROID
            if (Input.GetTouch(0)){
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else{
                return 0;
            }
            #endif*/
        }
        return UnityEngine.Input.GetAxis(axisName);
       }
         
    
}
