using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    bool is_running;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        is_running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != new Vector3(0.0f, 0.0f, 0.0f) && !is_running) {
            anim.SetBool("is_running", true);
            is_running = true;
        }
        else if (rb.velocity == new Vector3(0.0f, 0.0f, 0.0f) && is_running) {
            anim.SetBool("is_running", false);
            is_running = false;
        }
    }
}
