using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alfred : MonoBehaviour
{
    public Transform player;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }
}
