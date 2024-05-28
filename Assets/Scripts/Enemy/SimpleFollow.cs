using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class SimpleFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent)
        {
            if (player)
            {
                if (agent.enabled == true && canMove == true)
                {
                   
                        
                        agent.SetDestination(player.transform.position);
                   
                    
                } 
            }
        }
    }
}
