using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour //씬 이동하는 함수들 모음
{
    public Image image;
    public GameObject Loading;

    public void SignUpChange() //회원가입창 이동
    {
        SceneManager.LoadScene("Sign_Up");
    }


    public void LoginChange() //로그인창 이동, 회원가입 후 로그인창으로 이동합니다
    {
        SceneManager.LoadScene("Start_Login");
    }

    public void LobbyChange() //로그인 후 로비로 이동합니다
    {
        SceneManager.LoadScene("Lobby");
    }

    public void PalaceChange() //궁궐 이동
    {
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("PalaceSceneChange", 4.0f);
    }

    public void VilliageChange() //마을 이동
    {
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("VilliageSceneChange", 4.0f);
    }

     public void OndalChange() //온달집 이동

    { 
        image.gameObject.SetActive(true);
        StartCoroutine(Fadeout());
        Invoke("OndalSceneChange", 4.0f);
    }




    //이하는 맵 이동, 페이드아웃 코루틴

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


