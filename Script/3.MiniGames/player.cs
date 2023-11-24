using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    float speed = 6.4f;
    public GameObject gamePlayer;
    public AudioSource audioC;
    public AudioSource audioO;
    public AudioSource audioT;
    public MeshRenderer meshRenderer;
    Color ogColor;
    float flashDur = 3f;
    bool vulnerable = true;
    public GameObject Timer;
    float timePass = 0f;
    float timeTrack = 0.8f;
    public GameObject Results;
    // Start is called before the first frame update
    void Start()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        //ogColor = meshRenderer.material.color;

        audioT.Play();
    }
    private void Awake()
    {
        //audioC = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(MiniGame1Manager.Instance.GameStart)
        {
            speed = 6.4f;
        }
        else
        {
            speed = 0;
        }
        //timeTrack += Time.fixedDeltaTime;
        //if (Timer.activeInHierarchy || Results.activeInHierarchy)
        //{
        //    speed = 0;
        //}
        //else
        //{
        //    speed = 6.4f;
        //}

        //if (timeTrack - timePass >= 1 & timePass < 3)
        //{
        //    timePass += 1;
        //    audioT.Play();
        //}

        gamePlayer.transform.Translate(0, 0, 1 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "miniGameItem")
        {
            audioC.Play();
        }

        if (other.tag == "obstacle" && vulnerable)
        {
            FlashStart();
            audioO.Play();
            Destroy(other.gameObject);
            Score.instance.ScoreLoss();
            Flash();
        }

        if (other.tag == "end")
        {

        }
    }

    void FlashStart()
    {
        //meshRenderer.material.color = Color.white;
        Invoke("FlashStop", flashDur);
    }

    void FlashStop()
    {
        //meshRenderer.material.color = ogColor;
    }

    public IEnumerator Flash()
    {
        vulnerable = false;
        yield return new WaitForSeconds(flashDur);
        vulnerable = true;
    }
}
