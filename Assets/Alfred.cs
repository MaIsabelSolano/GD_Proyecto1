using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alfred : MonoBehaviour
{
    public Transform player;
    [SerializeField] GameObject jumpscare;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        jumpscare.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")){
            // game over
            jumpscare.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
