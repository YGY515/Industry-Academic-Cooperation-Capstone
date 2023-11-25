using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    bool isPaused;
    public GameObject ExitPopup;

    void Start()
    {
        isPaused = false;
        ExitPopup.SetActive(false);
    }
    void Update() //종료 팝업창 띄우기

    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            ExitPopup.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            ExitPopup.SetActive(false);
            isPaused = false;
        }
    }


    public void Quit() //'네' 누를 시 종료
    {
        //#if UNITY_STANDALONE
        Application.Quit();

        /*
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif*/

    }
}
