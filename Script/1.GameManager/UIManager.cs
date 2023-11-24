using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �ڵ�
using UnityEngine.UI;

//�̱��� ����
public class UIManager:MonoBehaviour
{
    private static UIManager instance = null;

    [SerializeField] GameObject upperUI;
    [SerializeField] GameObject moveUI;
    [SerializeField] GameObject dialogueUI;
    
    public static UIManager Instance // �ν��Ͻ��� �����ϴ� ������Ƽ
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
