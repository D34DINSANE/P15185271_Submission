using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/DavidT12/Unity-waypoint-System/blob/master/AImovement.cs
public class AImovement1 : MonoBehaviour
{
    public Transform path;


    public float speed = 20;
    public Rigidbody rbAI;
    public float turnSpeed = 5F;
    public float moveToNextWaypoint = 5f;
    private Vector3 currentWaypoint;

    private List<Transform> nodes;
    private int currentNode = 0;

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

        Vector3 relativePos = currentWaypoint - transform.position;//relativePos is the distence left to current waypoint



        currentWaypoint = nodes[currentNode].position;  //nodes[i].position;
        faceWaypoint(relativePos); //rotates object to face waypoint
        CheckNodeDistance(relativePos);
        MoveUFO();



        // LOOK AT THIS FOR FIX
        /*   for (int i = 0; i < nodes.Count; i++)
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
               }*/


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