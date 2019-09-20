using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityAI : MonoBehaviour
{
    public Transform path;
    private List<Transform> nodes;

    private int currentNode = 0;
    private int nodePosition = 0;

    public Rigidbody artyRigidbody;

    public float speed = 80f;
    public float turnSpeed = 10f;

    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    // public float maxTurnAnlge = 60f;

    private float powerInput;
    private float turnInput;

    void Awake()
    {
        artyRigidbody = GetComponent<Rigidbody>();
    }

     void Start()
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
       // Vector3 relativePos = currentNode - transform.position;
       // FaceNode(relativePos);
    }

    void Update()
    {
        // Vector3 currentNode = nodes.position;
        // powerInput = Input.GetAxis("Vertical");
        //  turnInput = Input.GetAxis("Horizontal");
      /*  Vector3 currentNode = nodes;
        Vector3 relativePos = currentNode - transform.position; //relativePos is the distence left to current waypoint
        NodeSelection(relativePos);       
        FaceNode(relativePos); //rotates object to face waypoint
        Moveobject();
        */

    }

    void Moveobject()
    {
        if (Mathf.Abs(speed) > Mathf.Abs(artyRigidbody.velocity.z + artyRigidbody.velocity.x))
        {
            artyRigidbody.AddForce(transform.forward * speed);
        }
    }


    void NodeSelection(Vector3 relativePos)
    {

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;

            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
        }

    }
        void FixedUpdate()
        {

           // FaceNode(relativePos);


            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, hoverHeight))
            {
                float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                artyRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
            }

            // artyRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
            // artyRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

        }

        void FaceNode(Vector3 relativePos)
        {

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);  // slerp ( from.rotation, to.rotation, speed)
        }

        /*
        //if current position is close to the current waypoint, look for the next waypoint
        if (Mathf.Abs(relativePos.x) < disChangeNode && Mathf.Abs(relativePos.z) < disChangeNode)
        {
            nodeListPosition++;//look for the next waypoint
            if (nodeListPosition < nodes.Count)//waypoints.Count shows number of elements in list
            {
                currentNode = nodes[nodeListPosition];
            }
            else  //loop back and start list again
            {
                nodes = 0;
            }

        }
        */
    }

    

   

  
    
