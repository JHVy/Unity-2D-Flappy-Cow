using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton, pauseButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    public void _InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void _CowDieShowPanel(int score)
    {
        gameOverPanel.SetActive(true);

        endScoreText.text = "" + score;
        if(score > GameManager.instance.GetHightScore())
        {
            GameManager.instance.SetHightScore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHightScore();
    }


    public void _MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void _RestartGameButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        instructionButton.gameObject.SetActive(false);
    }

    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

}
