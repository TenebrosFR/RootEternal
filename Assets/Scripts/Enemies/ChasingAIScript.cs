using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;

    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    private void Awake () {

        player = GameObject.Find(playerName).transform;
        agent = GetComponent<NavMeshAgent>();
    
    }

    private void Update() {

        transform.LookAt(player);
        agent.SetDestination(player.position);

    }

}
