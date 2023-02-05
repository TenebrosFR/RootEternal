using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour {
    NavMeshAgent agent;
    [SerializeField] EnemyHealth script;
    private void Init() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        transform.LookAt(ManagePlayer.player);
        if (agent) {
            if (!script.isGoingToDie) agent.SetDestination(ManagePlayer.player.position);
            else agent.SetDestination(transform.position);
        } else Init();
    }

}
