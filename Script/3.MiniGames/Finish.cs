using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject EndScreen;
    public Player_Camera Cam;

    public TMP_Text finalScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "miniGamePlayer")
        {
            MiniGame1Manager.Instance.GameEnd();
            EndScreen.SetActive(true);
            Cam.smoothTime = 0;

            finalScore.text = "최종 점수는" + Score.instance.currentScore + "점입니다.";
        }
    }
}
