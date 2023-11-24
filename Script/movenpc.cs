using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class movenpc : MonoBehaviour
{
    public float startTime; 

    public float minX, maxX;

    public float moveSpeed;

    private int sign = -1; //좌우
    

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= startTime)
        {
            //이동 로직 처리
            transform.position += new Vector3(moveSpeed*Time.deltaTime*sign, 0, 0);
            
            if(transform.position.x <= minX||transform.position.x >= maxX) //왔다갔다
            {
                sign*=-1;

                if(sign == 1)
                {
                    transform.eulerAngles = new Vector3(0,90,0);
                }
                else if (sign ==-1)
                {
                    transform.eulerAngles = new Vector3(0,-90,0);
                }
            }



            

            
        }
    }
}