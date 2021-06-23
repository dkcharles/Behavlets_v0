using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller; 

    public AudioClip jumpSound;
    public AudioClip PlayCollectBallSnd;
    public AudioSource AS;
    public float jumpForce = 100f;
    private bool goingUp = false;

    public float speed = 15f;
    public float gravity = -98f;
    Vector3 velocity; 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 
    bool isGrounded; 

    public float mouseSensitivity = 100f; 
    Transform playerBody; 
    Vector3 move;
    public float friction = 0.01f;
    
    float xRot = 0f;

    [SerializeField]    
    private GameObject CameraMountPoint;

    public void playCollectBallSnd()
    {
        if (PlayCollectBallSnd != null) AS.PlayOneShot(PlayCollectBallSnd);
    }

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked; // hide mouse cursor which can be distracting
        
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
                if (jumpSound != null) AS.PlayOneShot(jumpSound);
                
                goingUp = true;
                upForce = jumpForce;
                isGrounded = false;
            }
        }
        else
        {
            if (move.magnitude > 0) {
                // ? add friction due to wind resistance?
            }
        }

        if (isGrounded && velocity.y < 0) velocity.y = -2f; // pushes player closer to the ground

        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * speed * Time.deltaTime);

        if (goingUp) 
        {
            upForce -= 0.5f*Time.deltaTime;
            velocity.y += upForce; 
            if (upForce < 0) 
            {
                goingUp = false;
            }
        }
        controller.Move(velocity * Time.deltaTime);
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        Quaternion cameraAngle = CameraMountPoint.transform.localRotation;
        CameraMountPoint.transform.localRotation = Quaternion.Euler(xRot, cameraAngle.eulerAngles.y, cameraAngle.eulerAngles.z);  // angles are expresses as Quarternions 4D

        playerBody.Rotate(0, mouseX, 0);          
    }
}
