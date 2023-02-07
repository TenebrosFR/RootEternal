using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] LayerMask EnemyLayer;

    public int currentHealth;

    //
    public static Health instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        GameManager.instance.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameManager.instance.SetHealth(currentHealth);
        if (currentHealth <= 0) GameManager.instance.Death();
    }

    public void TakeHeal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        GameManager.instance.SetHealth(currentHealth);
        Debug.Log("Vie actuelle:" + currentHealth);
    }
}