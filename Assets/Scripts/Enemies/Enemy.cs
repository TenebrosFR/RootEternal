using UnityEngine;
using UnityEngine.VFX;
using utils;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int Hp;
    [SerializeField] Animator animator;
    [SerializeField] GameObject explosion;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask WeaponHolder;
    [SerializeField] public int damage;
    public bool isGoingToDie = false;
    // Start is called before the first frame update
    public void TakeDammage(int _damage) {
        if (Hp - _damage <= 0) {
            Destroy(gameObject);
        }
        else {
            Hp -= _damage;
            Debug.Log("HP = " + Hp);
        }
    }
    public void StartGloryKill() {
        animator.SetTrigger("GloryKill");
        isGoingToDie = true;
    }
    private void FixedUpdate() {
        if (!isGoingToDie) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RootExplode")) {
            ManagePlayer.ChangeLockState(false);
            transform.LookAt(ManagePlayer.player);
            Instantiate(explosion, transform.position.UpdateAxis(transform.position.y + 0.75f, VectorAxis.Y), explosion.transform.rotation * transform.rotation);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("isDead")) Destroy(gameObject);
    }   

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == Mathf.Log(WeaponHolder.value, 2)) {
            Health.instance.TakeDamage(damage);
        }
    }
}
