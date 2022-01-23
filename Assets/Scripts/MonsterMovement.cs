using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterMovement : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navmesh;
    public Transform[] points;
    int destPoint = 0;

    public bool foundPlayer = false;
    // Use this for initialization
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundPlayer) {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!navmesh.pathPending && navmesh.remainingDistance < 0.5f)
                GotoNextPoint();
            // Set the agent to go to the currently selected destination.
            navmesh.destination = points[destPoint].position;
        }
        if (foundPlayer) {
            navmesh.destination = player.transform.position;
        }
    }
    
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1);
        if (destPoint >= points.Length) {
            destPoint = 0;
        }
    }
}
