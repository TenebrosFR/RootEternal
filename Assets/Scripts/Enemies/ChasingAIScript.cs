using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour {
    NavMeshAgent agent;
    [SerializeField] EnemyHealth script;
    [SerializeField] Animator animator;
    public bool isStatic = false;
    private void Init() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        transform.LookAt(ManagePlayer.player);
        if (!isStatic && agent) {
            if(animator) animator.SetFloat("Velocity", agent.velocity.magnitude);
            if (!script.isGoingToDie) agent.SetDestination(ManagePlayer.player.position);
            else agent.SetDestination(transform.position);
        } else Init();
    }

}
