using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    [SerializeField] WeaponHolder weaponHolder;
    [SerializeField] LayerMask weaponLayer;
    [SerializeField] Camera cam;
    [SerializeField] float Distance;
    public void OnEquip(InputAction.CallbackContext context) {
        if (!context.performed) return;
        TryEquip();
    }
    void TryEquip() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray.origin, ray.direction, out RaycastHit firstHit, Distance);
        if (firstHit.transform && firstHit.transform.gameObject.layer == Mathf.Log(weaponLayer.value, 2)) {
            weaponHolder.weapon.SetInteger("ID",firstHit.transform.GetComponent<Weapon>().ID);
            Destroy(firstHit.transform.gameObject);
        }
    }
    public void OnHit(InputAction.CallbackContext context)
    {
        if (!context.performed)  return;
        Hit();
    }

    void Hit()
    {
        weaponHolder.PlayAnim();
    }
}
