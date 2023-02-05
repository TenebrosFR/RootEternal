using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingAIScript : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent agent;
    Transform player;
    [SerializeField] float timeBetweenAttacks;
    bool playerInAttackRange;

    [SerializeField] LayerMask EnemyShootRange;

    [SerializeField] GameObject projectiles;

    bool alreadyAttacked;

    private void Init() {
        player = ManagePlayer.player;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (player && agent) {
            if (playerInAttackRange) AttackPlayer();
            if (!playerInAttackRange) ChasePlayer();
            else Init();
        }
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

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack () {
        alreadyAttacked = false;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == Mathf.Log(EnemyShootRange.value, 2)) {
            playerInAttackRange = true;
        } else {
            playerInAttackRange = false;
        }
    }

}
