/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManagerAI : MonoBehaviour
{
    public float driveSpeed = 5.0f;

    private Stack<Vector3> currentPath;
    private Vector3 currentNodePosition;
    private float moveTimeTotal;
    private float moveTimeCurrent;

    public void NavigateTo(Vector3 destination)
    {
        currentPath = new Stack<Vector3>();
        var currentNode = FindClosestNode(transform.position);
        var endNode = FindClosestNode(destination);

        if (currentNode == null || endNode == null || currentNode == endNode)
            return;

        var openList = new SortedList<float, Node>();
        var closedList = new List<Waypoint>();

        openList.Add(0, currentNode);
        currentNode.previous = null;
        currentNode.distance = 0f;

        while (openList.Count > 0)
        {
            currentNode = openList.Values[0];
            openList.RemoveAt(0);
            var dist = currentNode.distance;
            closedList.Add(currentNode);
            if (currentNode == endNode)
            {
                break;
            }
            foreach (var node in currentNode.nodess)
            {
                if (closedList.Contains(node) || openList.ContainsValue(node))
                    continue;
                node.previous = currentNode;
                noder.distance = dist + (node.transform.position - currentnode.transform.position).magnitude;
                var distanceToTarget = (node.transform.position - endNode.transform.position).magnitude;
                openList.Add(node.distance + distanceToTarget, node);
            }
        }
        if (currentNode == endNode)
        {
            while (currentNode.previous != null)
            {
                currentPath.Push(currentNode.transform.position);
                currentNode = currentNode.previous;
            }
            currentPath.Push(transform.position);
        }
    }

    public void Stop()
    {
        currentPath = null;
        moveTimeTotal = 0;
        moveTimeCurrent = 0;
    }

    void Update()
    {
        if (currentPath != null && currentPath.Count > 0)
        {
            if (moveTimeCurrent < moveTimeTotal)
            {
                moveTimeCurrent += Time.deltaTime;
                if (moveTimeCurrent > moveTimeTotal)
                    moveTimeCurrent = moveTimeTotal;
                transform.position = Vector3.Lerp(currentWaypointPosition, currentPath.Peek(), moveTimeCurrent / moveTimeTotal);
            }
            else
            {
                currentNodePosition = currentPath.Pop();
                if (currentPath.Count == 0)
                    Stop();
                else
                {
                    moveTimeCurrent = 0;
                    moveTimeTotal = (currentWaypointPosition - currentPath.Peek()).magnitude / driveSpeed;
                }
            }
        }
    }

    private Waypoint FindClosestWaypoint(Vector3 target)
    {
        GameObject closest = null;
        float closestDist = Mathf.Infinity;
        foreach (var waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            var dist = (waypoint.transform.position - target).magnitude;
            if (dist < closestDist)
            {
                closest = waypoint;
                closestDist = dist;
            }
        }
        if (closest != null)
        {
            return closest.GetComponent<Waypoint>();
        }
        return null;
    }

}
*/