using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreAddText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] Animator waveAnim;
    [SerializeField] Animator scoreAnim;
    [SerializeField] GameObject settingMenu;
    public static Score instance;
    public void Awake()
    {
        settingMenu.SetActive(false);
        instance = this;
        if(scoreText!= null)
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

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
    public void SettingMenu()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        settingMenu.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Resume");
        Time.timeScale = 1;
        settingMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
}