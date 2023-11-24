using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrowOnBar : MonoBehaviour
{
    //[SerializeField]
    float[] speed = new float[4] { 20.0f, 30.0f, 10.0f, 15.5f }; // 화살표가 움직이는 속도.
    int speedIndex = 0;

   
    Vector3 currDir; // 화살펴가 움직이는 현재 방향
    public bool move = true;
 
    // Start is called before the first frame update
    void Start()
    {
        MiniGame3Manager.Instance.arrowOnBar = this; 
        currDir = Vector3.right; // 처음 방향은 오른쪽.
    }

    void Update()
    {
        if (move && MiniGame3Manager.Instance.start)
        {
            Vector3 arrowPos = transform.position;
            arrowPos += currDir * speed[speedIndex] * Time.deltaTime;


            if (arrowPos.x < -8.319f) // 오른쪽 끝
            {
                currDir *= -1.0f;
                transform.position = new Vector3(-8.319f, arrowPos.y,arrowPos.z);
            }
            else if (arrowPos.x > 8.199f)// 왼쪽 끝
            {
                currDir *= -1.0f;
                transform.position = new Vector3(8.199f, arrowPos.y, arrowPos.z);
            }
            else
            {
                transform.position = arrowPos;
            }
        }
    }

    public void ChangeSpeed()
    {
        speedIndex  = Random.Range(0, 4);
    }
     private void OnTriggerStay(Collider other)
    {
        if (move == false)
        {
            if (other.CompareTag("MG3perfect"))
            {
                    MiniGame3Manager.Instance.score = MiniGame3Score.Perfect;
                }
            else if (other.CompareTag("MG3good"))
            {
                    MiniGame3Manager.Instance.score = MiniGame3Score.Good;
            }
            else if (other.CompareTag("MG3hit"))
            { 
                MiniGame3Manager.Instance.score = MiniGame3Score.Hit;
            }
            else if (other.CompareTag("MG3miss"))
            {
                MiniGame3Manager.Instance.score = MiniGame3Score.Miss;
            }
        }
    }
}
