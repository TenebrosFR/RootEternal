using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    public static Score instance;

    public void AjoutPts(int pts){
        score += pts;
        Debug.Log("Points actuels:" + score);
        //scoreText.text = "Points actuels:" + score;
    }

    public void Awake()
    {
        instance= this;
    }
}