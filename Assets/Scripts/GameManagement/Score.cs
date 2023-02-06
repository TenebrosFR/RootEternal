using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreAddText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Animator waveAnim;
    [SerializeField] Animator scoreAnim;
    public static Score instance;
    public void Awake()
    {
        instance= this;
        AjoutPts(0);
    }

    public void AjoutPts(int pts){
        scoreAddText.text = "+ " + pts;
        scoreAnim.SetTrigger("fadeScore");
        score += pts;
        scoreText.text = "score: " + score;
    }

    public void WaveScreen(int _wave)
    {
        waveText.text = "Current wave: " + _wave;
        waveAnim.SetTrigger("fadeWave");
    }
}