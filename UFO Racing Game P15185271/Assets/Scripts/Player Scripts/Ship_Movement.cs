//This script handles all of the physics behaviors for the player's ship. The primary functions
//are handling the hovering and thrust calculations. 
using System.Collections;
using System.Collections.Generic;
//using Managers;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{

    float Timer = 0f;
    public float Ospeed = 90f; // Original Speed
    public float speed = 90f; // Current Speed
    public float turnSpeed = 10f; // Turn Speed
    public float hoverForce = 65f; // Hover force
    public float hoverHeight = 5f; // Hover height
    public Rigidbody ufoRigidbody; // Rigid body

    private float powerInput; // power input
    private float turnInput; // turning input
    

    // Could have been done another way but still works this way too. Simply wakes up the rigid body for use
    void Awake()
    {
        ufoRigidbody = GetComponent<Rigidbody>();
    }

    // Movement input
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        
        
    }

    // Ray casting hovering effect
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            ufoRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        ufoRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        ufoRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

        

    }

   
}

