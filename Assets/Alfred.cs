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
    [SerializeField] private float chaseDistance = 10f; // La distancia a la que el enemigo comenzará a perseguir al jugador
    [SerializeField] private Transform[] waypoints; // Los puntos de patrulla
    private int currentWaypoint = 0; // El punto de patrulla actual

    // Start is called before the first frame update
    void Start()
    {
        jumpscare.SetActive(false);
        agent.destination = waypoints[currentWaypoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            agent.destination = player.position;
        }
        else if (agent.remainingDistance < 0.5f) // Si el enemigo está cerca del waypoint actual
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length; // Pasar al siguiente waypoint
            agent.destination = waypoints[currentWaypoint].position; // Moverse al siguiente waypoint
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // game over
            jumpscare.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}