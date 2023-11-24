using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TMP_Text scoreCount;
    public int currentScore;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        scoreCount.text = currentScore.ToString();
    }

    public void ScoreGain()
    {
        currentScore += 1;
    }

    public void ScoreLoss()
    {
        currentScore -= 1;
    }
}
