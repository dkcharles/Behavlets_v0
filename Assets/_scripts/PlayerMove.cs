using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller; 
    public float jumpForce = 100f;
    private bool goingUp = false;

    public float speed = 12f;
    public float gravity = -98f;
    Vector3 velocity; 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 
    bool isGrounded; 

    public float mouseSensitivity = 100f; 
    Transform playerBody; 
    Vector3 move;
    public float friction = 0.1f;
    
    float xRot = 0f;
    public GameObject CameraMountPoint;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
        cameraTransform.parent = CameraMountPoint.transform;  //Make the camera a child of the mount point
        cameraTransform.position = CameraMountPoint.transform.position;  //Set position/rotation same as the mount point
        cameraTransform.rotation = CameraMountPoint.transform.rotation;
    }


    // Update is called once per frame
    private void Update()
    {
     
        playerBody = this.transform;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float upForce = 0;
        if (isGrounded)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            move = transform.right * x + transform.forward * z;
            
            if (Input.GetButtonDown("Jump"))
            {
                goingUp = true;
                upForce = jumpForce;
                isGrounded = false;
            }

        }
        else
        {
            if (move.magnitude > 0) move -= transform.right*Time.deltaTime*friction + transform.forward*Time.deltaTime*friction;
        }
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && velocity.y < 0) velocity.y = -4f;

        velocity.y += gravity * Time.deltaTime;
    
        if (goingUp) 
        {
            move.x = 0;
            upForce -= Time.deltaTime;
            velocity.y += upForce; 
            if (upForce < 0) 
            {
                goingUp = false;
            }
        }
        controller.Move(velocity * Time.fixedDeltaTime);
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);


        playerBody.Rotate(Vector3.up * mouseX);  
        
    }
}
