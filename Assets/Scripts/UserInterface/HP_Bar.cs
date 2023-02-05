using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    [SerializeField] private Health Health;
    [SerializeField] private Slider mySlider;
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

        mySlider.value = Health.health/100;
        textMesh.text = "HP " + Health.health + " / 100";
    }
}
