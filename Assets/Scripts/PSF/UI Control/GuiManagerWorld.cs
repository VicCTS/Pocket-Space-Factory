using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManagerWorld : MonoBehaviour
{
    public Transform mainCamera;
    
    public Transform canvas;
    public Image UI;

    void Start()
    {
        this.UI.rectTransform.localScale = new Vector3(1,1,1);
    }

    
    void Update()
    {
        this.canvas.rotation = this.mainCamera.rotation;
        this.canvas.localScale = Vector3.one * Vector3.Distance(this.mainCamera.position, this.canvas.position)/10; 
    }
}
