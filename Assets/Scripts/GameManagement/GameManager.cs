using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient = new Gradient();
    public Image fill;
    
    public TextMeshProUGUI hpNum;

    public GameObject restartScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        restartScreen.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        restartScreen.GetComponent<Canvas>().enabled = true;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Test");
    }
    
    public void SetHealth(int health)
    {
        hpNum.text = "HP " + health + " / 100";
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }
}