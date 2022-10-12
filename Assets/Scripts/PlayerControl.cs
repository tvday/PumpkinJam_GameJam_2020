using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent((typeof(Rigidbody)))]

public class PlayerControl : MonoBehaviour
{
    public float gravity = 20f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpSpeed = 8f;
    public float rotationSpeed = 2f;
    public float rotationXLimit = 45f;

    public Camera playerCamera;

    private Rigidbody rb;
    Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector] public static bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        
        canMove = true;
        
        // Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        //float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        moveDirection.y = rb.velocity.y;
        
        // if (Input.GetButton("Jump") && canMove )
        // {
        //     moveDirection.y = jumpSpeed;
        //     //rb.AddForce(Vector3.up * jumpSpeed);
        // }

        rb.velocity = (moveDirection);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        }
    }
}
