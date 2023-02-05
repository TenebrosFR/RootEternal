using System.Collections;
using System.Linq;
using utils;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    [SerializeField] float movementForce = 1;
    Vector3 currentDirection;
    
    public void OnMovement(InputAction.CallbackContext context) {
        if(!context.performed || ManagePlayer.isLocked) return;
        currentDirection = context.ReadValue<Vector3>();
    }

    void FixedUpdate() {
        var forwardMovement = (transform.forward * currentDirection.z).normalized;
        var sideMovement = (transform.right * currentDirection.x).normalized;
        if(!ManagePlayer.isLocked)rb.AddForce((forwardMovement + sideMovement).Restricted(false,true).normalized * Time.fixedDeltaTime * movementForce, ForceMode.VelocityChange);
    }
}
