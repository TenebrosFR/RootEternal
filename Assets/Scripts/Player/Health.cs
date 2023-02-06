using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Canvas restartScreen;
    [SerializeField] private LayerMask EnemyLayer;
    public int currentHealth;
    public TextMeshProUGUI textMesh;
    public HealthBar healthBar;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        restartScreen.enabled = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        slider.value = currentHealth;
        textMesh.text = "HP " + currentHealth + " / 100";
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == Mathf.Log(EnemyLayer.value, 2)) {
            TakeDamage(other.gameObject.GetComponent<Enemy>().damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
        
    }

    void Death()
    {
        restartScreen.enabled = true;
    }
    
    
}
