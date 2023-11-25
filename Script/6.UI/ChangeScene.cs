using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour //�� �̵��ϴ� �Լ��� ��Ƴ־����
{
    public Image image;
    public GameObject Loading;

    public void SignUpChange() //ȸ������â �̵�
    {
        SceneManager.LoadScene("Sign_Up");
    }


    public void LoginChange() //�α���â �̵�, ȸ������ �� �α���â���� �̵��մϴ�
    {
        SceneManager.LoadScene("Start_Login");
    }

    public void LobbyChange() //�α��� �� �κ�� �̵��մϴ�
    {
        SceneManager.LoadScene("Lobby");
    }

    public void PalaceChange() //�ñ� �̵�
    {
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("PalaceSceneChange", 4.0f);
    }

    public void VilliageChange() //���� �̵�
    {
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("VilliageSceneChange", 4.0f);
    }

     public void OndalChange() //�´��� �̵�

    { 
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("OndalSceneChange", 4.0f);
    }




    //���ϴ� �� �̵�, ���̵�ƿ� �ڷ�ƾ

    void OndalSceneChange()
    {
        Loading.SetActive(true);
        SceneManager.LoadScene("3.OndalMap_New");
    }

    void PalaceSceneChange()
    {
        Loading.SetActive(true);
        SceneManager.LoadScene("2.PalaceMap 1");
    }

    void VilliageSceneChange()
    {
        Loading.SetActive(true);
        SceneManager.LoadScene("1.MainMap_New");
    }

    IEnumerator Fadeout()
    {
        float alpha = 0;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        Loading.SetActive(true);
    }
}


