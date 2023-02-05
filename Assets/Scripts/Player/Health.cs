using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HP_Bar hpBar;
    [SerializeField] private int healthMax = 100;
    [SerializeField] private Canvas restartScreen;
    [SerializeField] private LayerMask EnemyLayer;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        restartScreen.enabled = false;
        health = healthMax;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == Mathf.Log(EnemyLayer.value, 2)) {
            TakeDamage(other.gameObject.GetComponent<Enemy>().damage);
        }
    }


    void TakeDamage(int damage)
    {
        health -= damage;
        hpBar.HPChange();
        if (health <= 0)
        {
            Death();
        }
        
    }

    void Death()
    {
        restartScreen.enabled = true;
    }
}
