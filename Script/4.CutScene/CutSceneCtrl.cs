using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneCtrl : MonoBehaviour
{
    [SerializeField] private int cutSceneId;
    [SerializeField] private string cutSceneName;
    [SerializeField] GameObject alramUI;
    [SerializeField] TMP_Text alarmTmp;
    [SerializeField] string alarmText;

    BoxCollider trigger;

    void Start()
    {
        trigger = gameObject.GetComponent<BoxCollider>();

        if (DataManager.Instance().NowPlayerAlarmData() && cutSceneId == DataManager.Instance().NowPlayerStroyData())
        {
            alarmTmp.text = alarmText;
            alramUI.SetActive(true);
            DataManager.Instance().nowPlayer.alarm = false;
            DataManager.Instance().SaveData();
        }
        if (DataManager.Instance().NowPlayerStroyData() >= cutSceneId)
        {
            gameObject.SetActive(false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(cutSceneName);
        }
    }
}
