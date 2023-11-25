using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerChoose : MonoBehaviour
{
    int num;
    GameObject Select;

    public GameObject girl;
    public GameObject boy;

    public GameObject girlCamera;
    public GameObject boyCamera;

    // Update is called once per frame
    void Start()
    {
        
        Select = GameObject.Find("PlayerSelect");  //�κ������ �ǳʿ� �÷��̾� ���� ������Ʈ�� �����մϴ�
        num = Select.GetComponent<CharacterSelect>().CharacterNumber;
        //StartCoroutine(Player());
    }
    void Update()
    {
        StartCoroutine(Player());
    }

    IEnumerator Player()
    {
        if (num == 1) //��ĳ�϶�
        {
            girl.gameObject.SetActive(true);
            boy.gameObject.SetActive(false);

            girlCamera.gameObject.SetActive(true);
            boyCamera.gameObject.SetActive(false);
        }
        else if (num == 2) //��ĳ�϶�
        { 

            boy.gameObject.SetActive(true);
            girl.gameObject.SetActive(false);

            boyCamera.gameObject.SetActive(true);
            girlCamera.gameObject.SetActive(false);
        }

        yield return null;
    }
}
