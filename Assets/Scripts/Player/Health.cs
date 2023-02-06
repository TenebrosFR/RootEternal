using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] Canvas restartScreen;
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] TextMeshProUGUI textMesh;
    public int currentHealth;
    public HealthBar healthBar;
    public Slider slider;
    //
    public static Health instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        restartScreen.enabled = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        slider.value = currentHealth;
        textMesh.text = "HP " + currentHealth + " / 100";
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0) Death();
    }

    public void TakeHeal(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth= maxHealth;
        }
        Debug.Log("Vie actuelle:" + currentHealth);
    }

    void Death()
    {
        restartScreen.enabled = true;
    }
}
