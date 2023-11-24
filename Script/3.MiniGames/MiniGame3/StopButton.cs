using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class StopButton : MonoBehaviour
{
    // 화살 프리팹
    public GameObject arrow;
    public Transform arrowPos;

    public Button pushButton;

    void Start()
    { 
        pushButton = GetComponent<Button>();
        MiniGame3Manager.Instance.stopbutton = this;
    }

    public void ClickPushButton()
    {
        pushButton.interactable = false; // 비활성화하기
        // Game Manager한테 버튼 클릭했는지 얘기해주자!
        MiniGame3Manager.Instance.arrowOnBar.move = false;
        MiniGame3Manager.Instance.shootCount += 1;
        Fire();
    }

    void Fire()
    {
        Instantiate(arrow, arrowPos.position, arrowPos.rotation);
    }
}
