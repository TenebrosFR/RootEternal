using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HP_Bar hpBar;
    [SerializeField] private int healthMax = 100;
    public int health;
    [SerializeField] private Canvas restartScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        restartScreen.enabled = false;
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(5);
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
