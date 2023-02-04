using UnityEngine;
using UnityEngine.InputSystem;

public class HitWeapon : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    public void OnHit(InputAction.CallbackContext context)
    {
        if (!context.performed && context.canceled)
        {
            return;
        }
        if (context.performed)
        {
            Hit(weapon);
        }
    }

    void Hit(Weapon _weapon)
    {
        weapon.PlayAnim();
    }
}
