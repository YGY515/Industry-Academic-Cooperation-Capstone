using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public enum MiniGame3Score
{
    Miss = 0,
    Hit,
    Good,
    Perfect,
}

public class MiniGame3Manager : MonoBehaviour
{
    private static MiniGame3Manager instance = null;

    [SerializeField]
    GameObject GameOverScreen;
    [SerializeField] private string BackToScene;
    public bool pause = false;

    public bool start = false;
    public ArrowOnBar arrowOnBar;
    public StopButton stopbutton;
    public MiniGame3Score score = MiniGame3Score.Miss;

    public int totalScore = 0;
    public TMP_Text totalScoreText;
    public int shootCount = 0;

    private void Awake()
    {
        GameOverScreen.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }

        totalScoreText.text = "0";
    }
    public static MiniGame3Manager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }   
    public void GetScore()
    {
        totalScore += ((int)score)* 10;
        totalScoreText.text = totalScore.ToString();
    }

    public void GameOver()
    {
        DataManager.Instance().updataMiniGameData(3);
        GameOverScreen.SetActive(true);
        SceneManager.LoadScene(BackToScene);
    }

    public void GameStart()
    {
        start = true;
    }
}
