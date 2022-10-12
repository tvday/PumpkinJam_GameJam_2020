using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 1.0f;
    public int repeat = 10;
    public AudioClip cat_meow;
    public GameObject player;

    private void OnEnable()
    {
        GameControl.OnDejaVu += CatRun;
    }

    private void OnDisable()
    {
        GameControl.OnDejaVu -= CatRun;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // CatRun(1.0f);
    }

    void CatRun()
    {
        
        StartCoroutine(CatCoroutine());
    }

    IEnumerator CatCoroutine(){
        rb.position = new Vector3(player.transform.position.x -1.0f, player.transform.position.y - 1.0f, player.transform.position.z -1.0f);
        
        Debug.Log("event trigger received");
        AudioSource.PlayClipAtPoint(cat_meow, Camera.main.transform.position);

        rb.velocity = Vector3.forward * speed;

        yield return new WaitForSeconds(5.0f);

        //rb.position = new Vector3(-.5f, 1f, -1f);
        rb.position = new Vector3(player.transform.position.x -1.0f, player.transform.position.y - 1.0f, player.transform.position.z -1.0f);
        
        Debug.Log("event trigger received");
        AudioSource.PlayClipAtPoint(cat_meow, Camera.main.transform.position);

        rb.velocity = Vector3.forward * speed;

        yield return null;
    }
}
