using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public Animator weapon;
    [SerializeField] public int damage;
    [SerializeField] Equipment equip;
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            other.transform.GetComponent<Enemy>().TakeDammage(damage);
        }
    }

    public void PlayAnim()
    {
        weapon.SetTrigger("HitAction");
    }

    private void FixedUpdate() {
        if (equip.col.enabled && animator.GetCurrentAnimatorStateInfo(0).IsName("Empty"))   equip.ChangeStateCollider(false);
    }
}
