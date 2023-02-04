using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    [SerializeField] WeaponHolder weaponHolder;
    [SerializeField] LayerMask weaponLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Camera cam;
    [SerializeField] float Distance;
    bool isLocked = false;
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
        if (!context.performed || isLocked)  return;
        weaponHolder.PlayAnim();
    }
    public void OnGloryKill(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray.origin, ray.direction, out RaycastHit firstHit, Distance);
        if (firstHit.transform && firstHit.transform.gameObject.layer == Mathf.Log(enemyLayer.value, 2)) {
            EnemyHealth enemy = firstHit.transform.GetComponent<EnemyHealth>();
            if (enemy.Hp <= weaponHolder.damage) {
                enemy.StartGloryKill();
                isLocked = true;
                //ToDo Rajouter animation cot� joueur (movement de main) quand le player seras fait
            }
        }
    }
}
