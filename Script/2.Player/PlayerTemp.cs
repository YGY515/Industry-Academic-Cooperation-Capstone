using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    static public PlayerTemp instance; // instance�� ���� ����
    public string currentMapName; // �̵��� �� �̸� ����



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
