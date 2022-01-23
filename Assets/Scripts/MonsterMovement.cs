using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterMovement : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navmesh;
    // Use this for initialization
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.destination = player.transform.position;
    }
}
