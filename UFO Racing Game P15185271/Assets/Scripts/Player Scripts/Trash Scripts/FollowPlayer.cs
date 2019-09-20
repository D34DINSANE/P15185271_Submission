using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;    // A variable that stores a reference to our Player
    public Vector3 offset;      // A variable that allows us to offset the position (x, y, z)

    // Update is called once per frame
    void Update()
    {
        // Set our position to the players position and offset it
        transform.position = player.position + offset;

       /* playerLastPosition = player.position - lookOnObject.normalized * offset;
        playerLastPosition.y = player.position.y + offset / 2;
        transform.position = playerLastPosition; */
    }

    
   
/*
    void Update()
    {
        Vector3 lookOnObject = player.position - transform.position;
        lookOnObject = player.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = player.position - lookOnObject.normalized * offset;
        playerLastPosition.y = player.position.y + offset / 2;
        transform.position = playerLastPosition;
    }


    */


}


