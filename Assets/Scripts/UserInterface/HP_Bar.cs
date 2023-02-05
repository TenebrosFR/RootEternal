using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HP_Bar : MonoBehaviour
{
    [SerializeField] private Health Health;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        HPChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPChange()
    {
        Debug.Log("Health.health",gameObject);
        _slider.value = Health.health;
        textMesh.text = "HP " + Health.health + " / 100";
    }
}
