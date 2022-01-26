using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class MonsterMovement : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navmesh;
    public GameObject[] pointsArray;
    private CapsuleCollider capCollider;
    private LinkedListNode<GameObject> currentPoint;
    private LinkedList<GameObject> points;

    public bool foundPlayer = false;
    // Use this for initialization
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        capCollider = GetComponent<CapsuleCollider>();
        points = new LinkedList<GameObject>(pointsArray);
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundPlayer)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!navmesh.pathPending && navmesh.remainingDistance < capCollider.radius * 3)
            {
                currentPoint = currentPoint?.Next ?? points.First;
                Debug.Log($"Current Point: {currentPoint.Value.name}");
            }
            // Set the agent to go to the currently selected destination.
            navmesh.destination = currentPoint.Value.transform.position;
        }
        if (foundPlayer)
        {
            navmesh.destination = player.transform.position;
        }

    }

}
