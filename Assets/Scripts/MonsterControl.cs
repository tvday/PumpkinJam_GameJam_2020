using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerLocation;
    private NavMeshAgent monster;
    private bool sent;
    
    public GameObject gameOverScreen;
    public Text score;
    DisplayScore scoreObj;

    private void OnEnable()
    {
        GameControl.OnSendMonster += SendMonster;
        GameControl.EndDejaVu += HideMonster;
    }
    
    private void OnDisable()
    {
        GameControl.OnSendMonster -= SendMonster;
        GameControl.EndDejaVu -= HideMonster;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreObj = score.GetComponent<DisplayScore>();
        monster = gameObject.GetComponent<NavMeshAgent>();
        monster.enabled = false;
        
        transform.position = new Vector3(0.5f, -5f, 7f);
        Debug.Log("moved monster " + transform.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (sent)
        {
            playerLocation = player.transform.position;
            monster.SetDestination(playerLocation);

            if (!PlayerHidingControl.isHiding)
            {
                monster.stoppingDistance = .625f;
            }
            else
            {
                monster.stoppingDistance = 5;
            }
        }
    }

    void SendMonster()
    {
        float yPos = player.transform.position.y;
        if (yPos < 4)
        {
            yPos = 2;
        }
        else if (yPos < 8)
        {
            yPos = 6;
        }
        else
        {
            yPos = 10;
        }

        gameObject.transform.position = new Vector3(0.5f, yPos, 7f);
        Debug.Log("moved monster " + transform.position.ToString());
        monster.enabled = true;
        if (scoreObj.GetCount() < 2)
        {
            monster.speed = 3;
        }
        else if (scoreObj.GetCount() < 6)
        {
            monster.speed = 2;
        }
        else
        {
            monster.speed = 1;
        }


        sent = true;
    }
    
    void HideMonster()
    {
        sent = false;
        monster.enabled = false;
        
        transform.position = new Vector3(0.5f, -5f, 7f);
        Debug.Log("moved monster " + gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !PlayerHidingControl.isHiding)
        {
            gameOverScreen.SetActive(true);
            // Unlock Cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Lock Player
            PlayerControl.canMove = false;
        }
    }
}
