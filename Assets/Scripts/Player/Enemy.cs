using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private NavMeshSurface surface;
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //agent.radius = 100f;
        surface.BuildNavMesh();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        print(agent.radius+" radius");
    }
}
