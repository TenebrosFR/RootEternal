using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    [SerializeField] WeaponHolder weaponHolder;
    [SerializeField] LayerMask weaponLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Camera cam;
    [SerializeField] float Distance;
    [SerializeField] public Collider col;

    public void OnInteract(InputAction.CallbackContext context) {
        if (!context.performed) return;
        TryEquip();
    }
    void TryEquip() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray.origin, ray.direction, out RaycastHit firstHit, Distance);
        if (firstHit.transform && firstHit.transform.gameObject.layer == Mathf.Log(weaponLayer.value, 2)) {
            weaponHolder.weapon.SetInteger("ID", firstHit.transform.GetComponent<Weapon>().ID);
            Destroy(firstHit.transform.gameObject);
            weaponHolder.SetWeaponMesh(firstHit.transform.GetComponent<Weapon>().ID);
        }
    }
    public void OnHit(InputAction.CallbackContext context)
    {
        if (!context.performed || ManagePlayer.isLocked)  return;
        ChangeStateCollider(true);
        weaponHolder.PlayAnim();
    }
    public void ChangeStateCollider(bool newState) {
        col.enabled = newState;
    }
    public void OnGloryKill(InputAction.CallbackContext context)
    {
        if (!context.performed || ManagePlayer.isLocked) return;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray.origin, ray.direction, out RaycastHit firstHit, Distance);
        if (firstHit.transform && firstHit.transform.gameObject.layer == Mathf.Log(enemyLayer.value, 2)) {
            Enemy enemy = firstHit.transform.GetComponent<Enemy>();
            if (enemy.Hp <= weaponHolder.damage) {
                enemy.StartGloryKill();
                ManagePlayer.ChangeLockState(true);
                //ToDo Rajouter animation cot� joueur (movement de main) quand le player seras fait
            }
        }
    }
}
