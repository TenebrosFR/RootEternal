using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour {
    [SerializeField] Enemy script;
    [SerializeField] Animator animator;
    [SerializeField] public bool isStatic = false;
    NavMeshAgent agent;
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
