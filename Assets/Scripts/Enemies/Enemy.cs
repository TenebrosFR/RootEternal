using UnityEngine;
using utils;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject collectiblePrefab;
    [SerializeField] Animator animator;
    [SerializeField] GameObject explosion;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask Player;
    [SerializeField] float damageInterval = 1f;
    [SerializeField] public int Hp;
    [SerializeField] public int damage;
    public bool isGoingToDie = false;
    private float hitTime;
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
        transform.rotation = Quaternion.LookRotation(ManagePlayer.player.position.UpdateAxis(transform.position.y, VectorAxis.Y) - transform.position, transform.up);
        if (!isGoingToDie) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RootExplode"))
        {
            ManagePlayer.ChangeLockState(false);
            transform.LookAt(ManagePlayer.player);
            Instantiate(explosion, transform.position.UpdateAxis(transform.position.y + 0.75f, VectorAxis.Y), explosion.transform.rotation * transform.rotation);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("isDead"))
        {
            Destroy(gameObject);
            GameObject collectible = Instantiate(collectiblePrefab);
            collectible.transform.position = transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(Player.value, 2)) {
            hitTime = Time.time;
            Health.instance.TakeDamage(damage);
        }
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(Player.value, 2) && Time.time > hitTime + damageInterval) {
            hitTime = Time.time;
            Health.instance.TakeDamage(damage);
        }
    }
}
