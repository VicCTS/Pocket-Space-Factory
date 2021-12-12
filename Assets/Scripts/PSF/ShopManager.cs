using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
    public GameObject BGShop;
    public PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerInteractionZone")
        {
            BGShop.GetComponent<Animator>().SetInteger("StateBox", 1);
            playerController.cantMove = true;
        }
    }

    public void HideBGShop()
    {
        BGShop.GetComponent<Animator>().SetInteger("StateBox", 2);
        playerController.cantMove = false;
    }
}
