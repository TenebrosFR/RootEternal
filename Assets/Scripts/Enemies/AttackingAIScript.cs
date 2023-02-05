using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAIScript : MonoBehaviour
{
    
    [SerializeField] string playerName;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] float timeBetweenAttacks, attackRange;
    [SerializeField] bool playerInAttackRange;

    private GameObject EnemyShootRange;

    [SerializeField] GameObject projectiles;

    bool alreadyAttacked;

    private void Start()
    {
        EnemyShootRange = GameObject.Find("EnemyShootRange");
    }
    
    private void Awake() {
        player = GameObject.Find(playerName).transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (playerInAttackRange) AttackPlayer(); 
        if (!playerInAttackRange) ChasePlayer();
    }

    private void ChasePlayer () {
        transform.LookAt(player);
        agent.SetDestination(player.position);        
    }

    private void AttackPlayer () {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked) {

            Rigidbody rb  = Instantiate(projectiles, transform.position + transform.forward, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 8f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack () {
        alreadyAttacked = false;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == EnemyShootRange.name) {
            playerInAttackRange = true;
        } else {
            playerInAttackRange = false;
        }
    }

}
