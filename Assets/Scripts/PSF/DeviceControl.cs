using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceControl : MonoBehaviour
{
  public GameObject joystick;
  public GameObject PCctrl;

    // Update is called once per frame
    void Awake()
    {
        #if UNITY_ANDROID
            joystick.SetActive(true);
            PCctrl.SetActive(false);
            #endif

    }
}
