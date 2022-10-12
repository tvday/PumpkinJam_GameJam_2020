using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class GameControl : MonoBehaviour
{
    public delegate void DejaVuAction();
    public static event DejaVuAction OnDejaVu;
    public static event DejaVuAction OnSendMonster;
    public static event DejaVuAction EndDejaVu;

    private bool isDejaVuing;
    private bool monsterSent;
    private float monsterSentAt;

    public GameObject gameOverScreen;
    
    public AudioClip IntenseMusic;
    public AudioClip NormalGameMusic;
    public AudioSource audio;

    //for checking if Game Over
    public Text score;
    DisplayScore scoreObj;
    float DejaVuTime;

    
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        scoreObj = score.GetComponent<DisplayScore>();
        DejaVuTime = Time.time;
        audio.clip = NormalGameMusic;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreObj.GetCount() == 0) {
            // Unlock Cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // end game
            SceneManager.LoadScene("Menu");
        }

        // random chance to start deja vu event withing certain amount of time
        //if (Input.GetKey(KeyCode.Space) && Time.time - DejaVuTime > 5.0f)
        if (!isDejaVuing && Time.time - DejaVuTime > Random.Range(10f + scoreObj.GetCount(), 30f))
        {
            isDejaVuing = true;
            OnDejaVu?.Invoke();
            StartCoroutine(ScaryMusic());
        }

        if (isDejaVuing && monsterSent && PlayerHidingControl.isHiding && Time.time - Math.Max(PlayerHidingControl.hiddenSince, monsterSentAt) > Random.Range(5f, 10f))
        {
            isDejaVuing = false;
            monsterSent = false;
            EndDejaVu?.Invoke();
            audio.Stop();
            audio.clip = NormalGameMusic;
            audio.Play();
            DejaVuTime = Time.time;
        }

    }

    IEnumerator ScaryMusic(){
        yield return new WaitForSeconds(7);
        audio.Stop();
        audio.clip = IntenseMusic;
        audio.Play();
        //AudioSource.PlayClipAtPoint(IntenseMusic, Camera.main.transform.position);
        yield return new WaitForSeconds(5);
        OnSendMonster?.Invoke();
        monsterSent = true;
        monsterSentAt = Time.time;

    }
}
