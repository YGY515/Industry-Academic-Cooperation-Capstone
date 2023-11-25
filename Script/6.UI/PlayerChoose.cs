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
        
        Select = GameObject.Find("PlayerSelect");  //로비씬에서 건너온 플레이어 성별 오브젝트를 참고합니다
        num = Select.GetComponent<CharacterSelect>().CharacterNumber;
        //StartCoroutine(Player());
    }
    void Update()
    {
        StartCoroutine(Player());
    }

    IEnumerator Player()
    {
        if (num == 1) //여캐일때
        {
            girl.gameObject.SetActive(true);
            boy.gameObject.SetActive(false);

            girlCamera.gameObject.SetActive(true);
            boyCamera.gameObject.SetActive(false);
        }
        else if (num == 2) //남캐일때
        { 

            boy.gameObject.SetActive(true);
            girl.gameObject.SetActive(false);

            boyCamera.gameObject.SetActive(true);
            girlCamera.gameObject.SetActive(false);
        }

        yield return null;
    }
}
