using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] int Hp;
    // Start is called before the first frame update
    public void TakeDammage(int _damage)
    {
        if(Hp - _damage <= 0)
        {
            Death();
        }
        else
        {
            Hp -= _damage;
            Debug.Log("HP = " + Hp);
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
