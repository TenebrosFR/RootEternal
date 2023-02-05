using UnityEngine;
using UnityEngine.VFX;
using utils;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int Hp;
    [SerializeField] Animator animator;
    [SerializeField] GameObject explosion;
    [SerializeField] Rigidbody rb;
    bool isGoingToDie = false;

    // Start is called before the first frame update
    public void TakeDammage(int _damage) {
        if (Hp - _damage <= 0) {
            Death();
        }
        else {
            Hp -= _damage;
            Debug.Log(Hp);
            Debug.Log("HP = " + Hp);
        }
    }
    void Death() {
        Destroy(gameObject);
    }
    public void StartGloryKill() {
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        animator.SetTrigger("GloryKill");
        isGoingToDie = true;
    }
    private void FixedUpdate() {
        if (!isGoingToDie) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("isDead")) {
            Instantiate(explosion, transform.position.UpdateAxis(transform.position.y + 0.75f,VectorAxis.Y),explosion.transform.rotation);
            ManagePlayer.ChangeLockState();
            Destroy(gameObject);
        }
    }
}
