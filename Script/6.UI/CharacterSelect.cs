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
        if (sceneName == "Lobby")  //�κ�â�϶��� �÷��̾� ���� ����
            {
                StartCoroutine(Select());
            }

    }

    
IEnumerator Select()
    {
        if (girl.gameObject.activeSelf)
        {
            CharacterNumber = 1; //��ĳ
        }
        if (boy.gameObject.activeSelf)
        {
            CharacterNumber = 2; //��ĳ
        }
        yield return null;
    }
}
