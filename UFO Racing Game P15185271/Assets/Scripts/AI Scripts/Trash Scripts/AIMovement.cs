using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement1 : MonoBehaviour {


   
    public float speed = 90f;
  //  public float maxSpeed = 80f;
    public float turnSpeed = 5f;
   // public float maxSteerAngle = 45f;
  //  public float maxMotorTorque = 80f;
    public float hoverForce = 65f;
    public float hoverHeight = 5f;

    public Rigidbody artyRigidbody;
    

    private float powerInput;
    private float turnInput;

    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;


    void Awake()
    {
        artyRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }


    void FixedUpdate()
    {

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            artyRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        artyRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        artyRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

        //  Drive();
        // CheckWaypointDistance();
    }

  /*  void Start ()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }
    */

    

    

    // Use this for initialization
  /*  private void ApplySteer ()
    {
        
	}
	*/
	// Update is called once per frame
	/*private void Drive()
    {
/*
        if (Mathf.Abs(maxSpeed) > Mathf.Abs(artyRigidbody.velocity.z + artyRigidbody.velocity.x))
        {
            artyRigidbody.AddForce(transform.forward * maxSpeed);
        }*/

      //  powerInput = Input.GetAxis("Vertical");
      //  turnInput = Input.GetAxis("Horizontal");



        /*
        Quaternion rotation = Quaternion.LookRotation(artyRigidbody.relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turn_speed);  // slerp ( from.rotation, to.rotation, speed)
        */
        /*
        //currentSpeed = 2 * Mathf.PI * artyRigidbody.radius
        artyRigidbody.motorTorque = maxMotorTorque;

        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);

        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        artyRigidbody.steerAngle = newSteer;
        */

    /*
    }
*/
    /*
    private void CheckWaypointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode]. position) < 0.5f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
    */
}
