using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideNotif : MonoBehaviour
{
    private Text notif;
    private bool playerHiding;

    private void OnEnable()
    {
        //PlayerControl.NearHidingSpot += ShowNotifHide;
        //PlayerControl.InHidingSpot += ShowNotifExit;
    }

    private void OnDisable()
    {
        //PlayerControl.NearHidingSpot -= ShowNotifHide;
        //PlayerControl.InHidingSpot -= ShowNotifExit;
    }

    // Start is called before the first frame update
    void Start()
    {
        notif = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //notif.text = "";
    }


    void ShowNotifHide()
    {
        notif.text = "Press E to Hide";
        if (Input.GetKeyDown(KeyCode.E))
        {
            notif.text = "Press E to Exit";
        }
    }
    
    void ShowNotifExit()
    {
        notif.text = "Press E to Exit";
    }
}
