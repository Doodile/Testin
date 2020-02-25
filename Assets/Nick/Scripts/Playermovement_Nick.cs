//Nick

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement_Nick : MonoBehaviour
{
    //References
    Rigidbody rigidboi;
    GameObject cameraObjectBoi;
    Camera cameraBoi;

    //Speed and look variables
    public float DEBUG_sprintSpeed = 5;
    public float walkSpeed = 2;
    public float acceleration = 2;
    public float maxLook = 70;
    public float verticalLookSpeed = 2;
    public float controllerLookMultiplier = 2;

    public bool DEBUG_MODE = false;
    bool CanMove = true;
    float moveSpeed;
    float lookUpRot = 0;

    //VV Movement Addition Variables
    //Movement
    float VerticalMove = 0;
    float HorizontalMove = 0;
    float VerticalVelocity = 0;
    float HorizontalVelocity = 0;

    //Look
    float VerticalLook = 0;
    float HorizontalLook = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = walkSpeed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //VV Get References VV
    void Awake()
    {
        rigidboi = GetComponent<Rigidbody>();
        //Get child Gameobject with camera
        cameraObjectBoi = transform.GetChild(0).gameObject;
        //Get camera from child
        cameraBoi = cameraObjectBoi.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //If sprint is pressed, set max speed to sprint speed
        if (Input.GetButtonDown("Sprint") && DEBUG_MODE)
        {
            moveSpeed = DEBUG_sprintSpeed;
        }
        if (Input.GetButtonUp("Sprint") && DEBUG_MODE)
        {
            moveSpeed = walkSpeed;
        }
    }

    //Movement and look update
    void FixedUpdate()
    {
        //If player can't move, set speed to 0
        if (!CanMove)
        {
            HorizontalVelocity = 0;
            VerticalVelocity = 0;

            rigidboi.velocity = Vector3.zero;
            return;
        }
            
        //Move and Look
        rigidboi.velocity = new Vector3(0, rigidboi.velocity.y, 0);
        VerticalLook = Input.GetAxisRaw("Mouse Y") + (Input.GetAxisRaw("CtlrLookY") * controllerLookMultiplier);
        HorizontalLook = Input.GetAxisRaw("Mouse X") + (Input.GetAxisRaw("CtlrLookX") * controllerLookMultiplier);

        //Add rotation to variable and clamp
        lookUpRot += -VerticalLook;
        lookUpRot = Mathf.Clamp(lookUpRot, -maxLook, maxLook);

        cameraObjectBoi.transform.rotation = Quaternion.Euler(lookUpRot, cameraObjectBoi.transform.eulerAngles.y, cameraObjectBoi.transform.eulerAngles.z);

        //Apply rotation
        transform.Rotate(new Vector3(0, HorizontalLook, 0));

        VerticalMove = Input.GetAxisRaw("Vertical");
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        //CalculateAndAddVelocity();

        //Calculate velocity and add to rigidbody
        VerticalVelocity = Mathf.Lerp(VerticalVelocity, VerticalMove, Time.deltaTime * acceleration);
        HorizontalVelocity = Mathf.Lerp(HorizontalVelocity, HorizontalMove, Time.deltaTime * acceleration);

        rigidboi.velocity = rigidboi.velocity + (transform.forward * VerticalVelocity) * moveSpeed;
        rigidboi.velocity = rigidboi.velocity + (transform.right * HorizontalVelocity) * moveSpeed;
    }

    //Set can the player move or not.
    internal void SetCanMove(bool setTo)
    {
        CanMove = setTo;
    }

    //Smooth Move Calculation
    void CalculateAndAddVelocity()
    {
        VerticalVelocity = Mathf.Lerp(VerticalVelocity, VerticalMove, Time.deltaTime * acceleration);
        HorizontalVelocity = Mathf.Lerp(HorizontalVelocity, HorizontalMove, Time.deltaTime * acceleration);

        rigidboi.velocity = rigidboi.velocity + (transform.forward * VerticalVelocity) * moveSpeed;
        rigidboi.velocity = rigidboi.velocity + (transform.right * HorizontalVelocity) * moveSpeed;
    }
}
