using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class StopButton : MonoBehaviour
{
    // ȭ�� ������
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
        pushButton.interactable = false; // ��Ȱ��ȭ�ϱ�
        // Game Manager���� ��ư Ŭ���ߴ��� ���������!
        MiniGame3Manager.Instance.arrowOnBar.move = false;
        MiniGame3Manager.Instance.shootCount += 1;
        Fire();
    }

    void Fire()
    {
        Instantiate(arrow, arrowPos.position, arrowPos.rotation);
    }
}
