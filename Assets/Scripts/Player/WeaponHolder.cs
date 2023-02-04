using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public Animator weapon;
    [SerializeField] public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            other.transform.GetComponent<EnemyHealth>().TakeDammage(damage);
        }
        else {
        }
    }

    public void PlayAnim()
    {
        weapon.SetTrigger("HitAction");
    }
}
