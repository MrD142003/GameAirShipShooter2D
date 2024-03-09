using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public int score = 0;
    [SerializeField] private Text scoreText, yourScoreText, highScoreText;
    [SerializeField] GameObject gameOverPanel, pausePanel;
    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void SetScore(int score)
    {
        this.score += score;
        scoreText.text = "" + this.score;
    }

    public void AirPlaneDiedShowPanel()
    {

        gameOverPanel.SetActive(true);
        yourScoreText.text = "" + score;
        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        highScoreText.text = "" + GameManager.instance.GetHighScore();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReStartGameButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

}
