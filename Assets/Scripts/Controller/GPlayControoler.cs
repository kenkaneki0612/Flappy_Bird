using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPlayControoler : MonoBehaviour
{

    public static GPlayControoler instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endscoreText, bestscoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    void _MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _setScore(int score) {
        scoreText.text = "" + score;
    }

    public void _BirdDiedShowPanel(int score){
        gameOverPanel.SetActive (true);

        endscoreText.text = "" + score;
        if(score > GameManager.instance.GetHighScore()) {
            GameManager.instance.SetHighScore (score);
        }

        bestscoreText.text = "" + GameManager.instance.GetHighScore();
    }

    public void _MenuButton() {
        SceneManager.LoadScene("MainMenu");
        //Application.LoadLevel("MainMenu");
    }

    public void _RestartMenuButton(){
        SceneManager.LoadScene("SampleScene");
        //Application.LoadLevel("SampleScene");
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void _PauseButton(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void _ResumeButton(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
