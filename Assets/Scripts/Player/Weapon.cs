using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator weapon;
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            other.transform.GetComponent<Ennemy>().TakeDammage(damage);
        }
    }

    public void PlayAnim()
    {
        weapon.SetTrigger("HitAction");
    }
}
