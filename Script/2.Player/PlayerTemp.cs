using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    static public PlayerTemp instance; // instance의 값을 공유
    public string currentMapName; // 이동할 맵 이름 저장



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
