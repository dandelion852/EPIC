using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveRigidBody : MonoBehaviour
{
    // Add the variables
    public float speed = 100f; // Speed variable
    public Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement; // Set the variable 'movement' as a Vector3 (x,y,z)

    public float throttleLeft = 0f;
    public float throttleRight = 0f;
    public float rotationSpeed = 0f;
    private float Yangle = 0f;
    private float Xangle = 0f;
    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody>();
    }



    // 'Update' Method is called once per frame
    void Update()
    {
        // In Update we get the Input for left, right, up and down and put it in the variable 'movement'...
        // We only get the input of x and z, y is left at 0 as it's not required
        // 'Normalized' diagonals to prevent faster movement when two inputs are used together
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    //AcsendingDescending
    public void OnThrottleLeft(InputValue value) 
    {
        throttleLeft = value.Get<float>();
        Debug.Log("UpDown - Left Thottle Value: " + throttleLeft);
    }

    //Speed
    public void OnThrottleRight(InputValue value)
    {
        throttleRight = (value.Get<float>())*10f;
        Debug.Log("AdditionalSpeed - Right Thottle Value: " + throttleRight);
    }

    //Rotate - Direction
    public void OnJoystickX(InputValue value)
    {
        Yangle = (value.Get<float>()) * .5f;
        Debug.Log("Y Rotation" + Yangle); //Y axis rotation for unity orientation
    }

    public void OnJoystickY(InputValue value)
    {
        Xangle = (value.Get<float>()) * .5f;
        Debug.Log("X Rotation" + Xangle); //X axis rotation for unity orientation
    }
    

    //use button to rescale scales (Toggle)
    public void OnGreyButton()
    {
        printTest();
    }

    private void printTest()
    {               
        Debug.Log("Button Pressed");
    }

    

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        //Using Fixed Movement
        //Vector3 verticalMovement = new Vector3(0, throttleLeft*0.05f, 0);
        //moveCharacter(verticalMovment);

        //Using Forces///////////////////
        Vector3 verticalMovement = new Vector3(0, (throttleLeft)*5f, 0);
        //Vector3 AddSpeed = new Vector3(0, 0, throttleRight);
        rb.AddRelativeForce(Vector3.forward * throttleRight);
        rb.AddForce(verticalMovement);
        //rb.AddForce(AddSpeed);

        //Direction
        if (Mathf.Abs(Yangle) > 0.1f && rb != null) // Adding a dead zone
        {
            Vector3 Yrotate = Vector3.up * Yangle * rotationSpeed;
            rb.AddRelativeTorque(Yrotate, ForceMode.Force);
        }
        else
        {
            rb.angularVelocity = Vector3.zero; //Stop Rotation
        }

        if (Mathf.Abs(Xangle) > 0.1f && rb != null) // Adding a dead zone
        {
            Vector3 Xrotate = Vector3.right * Xangle * rotationSpeed;
            rb.AddRelativeTorque(Xrotate, ForceMode.Force);
        }
        else
        {
            rb.angularVelocity = Vector3.zero; //Stop Rotation
        }

        moveCharacter(movement); // We call the function 'moveCharacter' in FixedUpdate for Physics movement
    }



    // 'moveCharacter' Function for moving the game object
    void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

}