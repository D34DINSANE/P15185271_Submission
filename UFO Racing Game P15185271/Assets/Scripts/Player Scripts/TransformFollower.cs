using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the camera, allowing it to follow the player
public class TransformFollower : MonoBehaviour
{
    [SerializeField] // Serialize field simply allows me to assign values etc in the unity coding interface even when private
    private Transform player;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    // Keeps updating position
    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = player.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}