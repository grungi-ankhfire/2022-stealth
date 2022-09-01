using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    
    private NavMeshAgent agent;
    public Transform playerTransform;
    private Transform waypointTransform;
    public Transform groupTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetNewDestination();
    }

    void GetNewDestination() {
        Transform currentDestination = waypointTransform;

        do {
            int index = Random.Range(0, groupTransform.childCount);
            waypointTransform = groupTransform.GetChild(index);
        } while(waypointTransform == currentDestination);

        agent.SetDestination(waypointTransform.position);
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform == waypointTransform) {
            GetNewDestination();
        }
    }


    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(transform.forward, playerTransform.position - transform.position);

        if (angle <= 45) {
            print("DETECTED!!!");
        }

    }
}
