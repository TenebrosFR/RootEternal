using UnityEngine;
using UnityEngine.AI;

public class ChasingAIScript : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

    private void Init() {
        player = ManagePlayer.player;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (!player || !agent) Init();
        else {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
    }

}
