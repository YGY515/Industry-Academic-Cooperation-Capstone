using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CutScenePlayer : MonoBehaviour
{
    UIManager ugMagr;

    [SerializeField]
    private PlayerInputsManager input;
    [SerializeField]
    private PlayableDirector pd;
    [SerializeField]
    public TimelineAsset[] ta;

    // Start is called before the first frame update
    private void Awake()
    {
        ugMagr = UIManager.Instance;
        //input = GetComponent<PlayerInputsManager>();
       // pd = GetComponent<PlayableDirector>();
        pd.stopped += OnPlayableDirectorStopped; // end call back 추가.
    }
    void Start()
    {
        //ugMagr = UIManager.Instance;
       // input = GetComponent<PlayerInputsManager>();
       // pd = GetComponent<PlayableDirector>();
        //pd.stopped += OnPlayableDirectorStopped; // end call back 추가.
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    // 처음 컷씬 볼 때 적용!!
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            input.move = Vector2.zero; // 입력 막음.
            ugMagr.CutSceneModeOn();
            Debug.Log("COLIID");
            gameObject.SetActive(false);
            //other.gameObject.SetActive(false); // 이제 콜라이더 버림.
            pd.Play();
        }
    }

    // Playable Dircetor의 end callback
    private void OnPlayableDirectorStopped(PlayableDirector a)  //Why is this Argument required
    {
        if (pd == a) //Why is this required?
        {
            ugMagr.CutSceneModeOff();
        }
    }
}
