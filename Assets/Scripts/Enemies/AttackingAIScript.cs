  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using utils;

public class AttackingAIScript : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent agent;
    Transform player;
    [SerializeField] float timeBetweenAttacks;
    bool playerInAttackRange;

    [SerializeField] LayerMask PlayerMask;
    [SerializeField] GameObject projectiles;

    GameObject projectileAlive;

    bool alreadyAttacked;

    private void Init() {
        player = ManagePlayer.player;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (player && agent) {
            if (playerInAttackRange && !projectileAlive) AttackPlayer();
            if (!playerInAttackRange && !projectileAlive) ChasePlayer();
        }
        else Init();
    }

    private void ChasePlayer () {
            agent.SetDestination(player.position);
    }

    private void AttackPlayer () {
        agent.SetDestination(transform.position);

        if (!alreadyAttacked) {
            projectileAlive = Instantiate(projectiles, (transform.position + transform.forward).UpdateAxis(ManagePlayer.player.position.y * 2, VectorAxis.Y), Quaternion.LookRotation(new Vector3(ManagePlayer.player.position.x, ManagePlayer.player.position.y - 1, ManagePlayer.player.position.z) - transform.position));

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack () {
        alreadyAttacked = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == Mathf.Log(PlayerMask.value, 2)) {
            playerInAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == Mathf.Log(PlayerMask.value, 2)) {
            playerInAttackRange = false;
        }
    }

}
