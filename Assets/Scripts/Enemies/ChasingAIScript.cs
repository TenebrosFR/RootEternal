using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour {
    [SerializeField] Enemy script;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask player;
    [SerializeField] public bool isStatic = false;
    NavMeshAgent agent;
    private void Init() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (!isStatic && agent) {
            if(animator) animator.SetFloat("Velocity", agent.velocity.magnitude);
            if (!script.isGoingToDie) agent.SetDestination(ManagePlayer.player.position);
            else agent.SetDestination(transform.position);
        } else Init();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(player.value, 2)) {
            animator.SetBool("Attack", true);
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(player.value, 2)) {
            animator.SetBool("Attack", false);
        }
    }

}
