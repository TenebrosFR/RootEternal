using System;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    public static bool isLocked = false;
    [SerializeField] Rigidbody playerRigidbody;
    public static Transform player;
    private void Start() {
        player = transform;
    }
    public static void ChangeLockState() {
        isLocked = !isLocked;
    }
}
