using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int Hp;
    [SerializeField] Animator animator;
    bool isGoingToDie = false;
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
    public void StartGloryKill() {
        animator.SetTrigger("GloryKill");
        isGoingToDie = true;
    }
    private void FixedUpdate() {
        if (!isGoingToDie) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("isDead")) Destroy(gameObject);
    }
}
