using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    public static bool isLocked = false;
    public static Transform player;
    [SerializeField] Rigidbody playerRigidbody;
    private void Start() {
        player = transform;
    }
    public static void ChangeLockState(bool newState) {
        isLocked = newState;
    }
}
