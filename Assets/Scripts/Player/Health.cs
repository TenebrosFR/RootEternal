using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] private GameManager _gameManager;
    public int currentHealth;

    //
    public static Health instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        //_gameManager.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //_gameManager.SetHealth(currentHealth);
        if (currentHealth <= 0) _gameManager.Death();
    }

    public void TakeHeal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        //_gameManager.SetHealth(currentHealth);
        Debug.Log("Vie actuelle:" + currentHealth);
    }
}