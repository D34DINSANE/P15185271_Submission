using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody rb;
    
    public float speed = 100.0f;
    public float rotationSpeed = 20.0f;
    public float totalRotation = 0;
    public float rotationAmount = 20f;

    void Update()
    {

        if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationAmount))
        {
            float currentAngle = rb.transform.rotation.eulerAngles.x;
            rb.transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * 5), Vector3.right);
            totalRotation += Time.deltaTime * 5;
        }

        if (Input.GetKeyDown(KeyCode.A) ) 
        {
            //  rb.velocity = -transform.right * speed;
            //  rb.velocity = new Vector3(-1, 0, 0) * speed;
            rb.transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.A) )
        {
            //  rb.velocity = -transform.right * speed;
            // rb.velocity = new Vector3(0, 0, 0);
            rb.transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //  rb.velocity = transform.right * speed;
            // rb.velocity = new Vector3(1, 0, 0) * speed;
            rb.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            //  rb.velocity = -transform.right * speed;
            // rb.velocity = new Vector3(0, 0, 0);
            rb.transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            //  rb.velocity = -transform.right * speed;
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector3(0, 0, -1) * speed;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            //  rb.velocity = -transform.right * speed;
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    

}
        /*
        // Fixed update is used due to the fixed alteration to the player physics
        void FixedUpdate()
        {
            // Add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey("d"))  // If the player is pressing the "d" key
            {
                // Add a force to the right
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("a"))  // If the player is pressing the "a" key
            {
                // Add a force to the left
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            }
        }
        */
    
