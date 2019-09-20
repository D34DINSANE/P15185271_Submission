using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFollow : MonoBehaviour {

    public Transform path; // The path of nodes
    public float speed = 65f; // Speed variable
    public float Ospeed = 65f; // Original speed variable
    public Rigidbody rbAI; // Rigid Body
    public float turnSpeed = 10f; // Turn speed variable
    public float moveToNextWaypoint = 1f; // Distance from node to move to next
    private Vector3 currentWaypoint; // current waypoint
    private List<Transform> nodes; // The actual list of nodes
    private int currentNode = 0; // Current Node

    public float hoverForce = 65f; // Hover force
    public float hoverHeight = 5f; // Height above the ground

    private float powerInput; // Input of power
    private float turnInput; // Turning input



    //private float start_game = 0;


    void Start()
    {
        rbAI = GetComponent<Rigidbody>();

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>(); //empty the list at the beginning

        for (int i = 0; i < pathTransform.Length; i++) //loops through each transform and picks one out
        {
            if (pathTransform[i] != path.transform) //checks if it's our own transform
            {
                nodes.Add(pathTransform[i]); //if not then it adds it to the nodes array
            }
        }
        

        Vector3 relativePos = currentWaypoint - transform.position;
        faceWaypoint(relativePos); //rotates object to face waypoint

    }



    void Update()
    {

        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        
        // CHANGING THIS ORDER WILL MESS IT UP. SO DONT!
        currentWaypoint = nodes[currentNode].position;  // Current node position
        Vector3 relativePos = currentWaypoint - transform.position;//relativePos is the distence left to current waypoint
        CheckNodeDistance(relativePos); // Check node distance in relation to current position
        faceWaypoint(relativePos); //rotates object to face waypoint
        
        MoveUFO(); 
    }

    void FixedUpdate()
    {
        // Raycasting to find distance between ground to create hovering effect

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            rbAI.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        rbAI.AddRelativeForce(0f, 0f, powerInput * speed);
        rbAI.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);


    }


    void MoveUFO()
    {
        if (Mathf.Abs(speed) > Mathf.Abs(rbAI.velocity.z + rbAI.velocity.x))
        {
            rbAI.AddForce(transform.forward * speed);
        }
    }

    void faceWaypoint(Vector3 relativePos)
    {
        // Rotating equations to face waypoints
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);  // slerp ( from.rotation, to.rotation, speed)
    }




    void CheckNodeDistance(Vector3 relativePos)
    {
        //if current position is close to the current waypoint, look for the next waypoint
        if (Mathf.Abs(relativePos.x) < moveToNextWaypoint && Mathf.Abs(relativePos.z) < moveToNextWaypoint)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }

        }
    }
}
