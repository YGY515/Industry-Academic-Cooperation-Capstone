using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update

    //public AudioSource src;
    //public AudioClip srcOne;

    public string NowScene;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        NowScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != NowScene)
        {
 
                Destroy(this.gameObject);
            
        }
    }
}
