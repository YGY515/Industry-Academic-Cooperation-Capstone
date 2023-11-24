using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI;

//싱글톤 패턴
public class UIManager:MonoBehaviour
{
    private static UIManager instance = null;

    [SerializeField] GameObject upperUI;
    [SerializeField] GameObject moveUI;
    [SerializeField] GameObject dialogueUI;
    
    public static UIManager Instance // 인스턴스에 접근하는 프로퍼티
    {
        get
        {
            if (instance == null)
               instance = FindObjectOfType<UIManager>();
               DontDestroyOnLoad(instance.gameObject);
            return instance;
        }
    }

    public void DialogueModeOn()
    {
        moveUI.SetActive(false);
    }
    public void DialogueModeOff()
    {
        moveUI.SetActive(true);
    }
    public void CutSceneModeOn()
    {
        moveUI.SetActive(false);
        upperUI.SetActive(false);
      //  dialogueUI.SetActive(false);
    }
    public void CutSceneModeOff()
    {
        moveUI.SetActive(true);
        upperUI.SetActive(true);
       // dialogueUI.SetActive(true);
    }
}
