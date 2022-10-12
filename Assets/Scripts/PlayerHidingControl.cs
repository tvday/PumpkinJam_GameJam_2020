using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHidingControl : MonoBehaviour
{
    
    public static bool isHiding;
    public Text HideTextNotif;
    public Image BlackOut;
    private float coolDownTimer;
    public float coolDownTime = 0.5f;
    public static float hiddenSince;
    
    // Start is called before the first frame update
    void Start()
    {
        coolDownTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag($"hidingSpot"))
        {
            if (!isHiding)
            {
                HideTextNotif.text = "Press E to Hide";
                if (Input.GetKey(KeyCode.E) && Time.time - coolDownTimer > coolDownTime)
                {
                    PlayerControl.canMove = false;
                    coolDownTimer = Time.time;
                    hiddenSince = Time.time;
                    isHiding = true;
                    BlackOut.enabled = true;
                    HideTextNotif.text = "Press E to Exit";
                }
            }
            else
            {
                HideTextNotif.text = "Press E to Exit";
                if (Input.GetKey(KeyCode.E) && Time.time - coolDownTimer > coolDownTime)
                {
                    PlayerControl.canMove = true;
                    coolDownTimer = Time.time;
                    isHiding = false;
                    BlackOut.enabled = false;
                    HideTextNotif.text = "Press E to Hide";
                }
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("hidingSpot"))
        {
            HideTextNotif.text = "";
        }
    }
}
