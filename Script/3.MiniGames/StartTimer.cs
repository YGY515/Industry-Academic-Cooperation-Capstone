using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    public TMP_Text startTimer;
    float timeTrack = 0.8f;
    int timePass = 0;
    int countdown;
    int timerSec = 3;
    public GameObject timer;

    private void FixedUpdate()
    {

        timeTrack += Time.fixedDeltaTime;

        if (timeTrack - timePass >= 1 & timePass < 3)
        {
            timePass += 1;
        }

        countdown = timerSec - timePass;
        startTimer.text = countdown.ToString();

        if (countdown == 0)
        {
            timer.SetActive(false);
        }
    }
}
