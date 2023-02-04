using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public Animator weapon;
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
        Debug.Log("isdfufgbvrk,jhyufqdgbfjhd;gvesdbh:j");
        weapon.SetTrigger("HitAction");
    }
}
