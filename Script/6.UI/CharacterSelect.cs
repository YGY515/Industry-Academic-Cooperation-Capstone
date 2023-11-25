using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int CharacterNumber = 1;
    public GameObject girl;
    public GameObject boy;

    // Update is called once per frame
    void Start()
    {
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "Lobby")  //로비창일때만 플레이어 성별 고르기
            {
                StartCoroutine(Select());
            }

    }

    
IEnumerator Select()
    {
        if (girl.gameObject.activeSelf)
        {
            CharacterNumber = 1; //여캐
        }
        if (boy.gameObject.activeSelf)
        {
            CharacterNumber = 2; //남캐
        }
        yield return null;
    }
}
