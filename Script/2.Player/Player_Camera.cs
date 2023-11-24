using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    //private Camera SmoothCam;
    public Transform playerPosition;
    public Transform playerPosition2; //남플래이어 포지션

    Vector3 cameraNextPosition;
    public float smoothTime = 0.1f;
    float x = .0f, y = .0f, z = .0f;

    void Awake()
    {
        //SmoothCam = GetComponent<Camera>();
        transform.eulerAngles = new Vector3(30.0f, 0.0f, 0.0f);
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        if ((playerPosition != null) || (playerPosition2 != null))  //두 플레이어 포지션 중 하나라도 들어왔을 때
        {
            if (playerPosition2 != null)  //사용자가 여캐 선택했을 때
            {
                cameraNextPosition = transform.position;

                cameraNextPosition.x = Mathf.SmoothDamp(transform.position.x, playerPosition.position.x, ref x, smoothTime);
                cameraNextPosition.z = Mathf.SmoothDamp(transform.position.z, playerPosition.position.z - 5.33f, ref z, smoothTime);
                cameraNextPosition.y = Mathf.SmoothDamp(transform.position.y, playerPosition.position.y + 5.33f, ref y, smoothTime);
            }

            if (playerPosition != null)  //사용자가 남캐 선택했을 때
            {
                cameraNextPosition = transform.position;

                cameraNextPosition.x = Mathf.SmoothDamp(transform.position.x, playerPosition2.position.x, ref x, smoothTime);
                cameraNextPosition.z = Mathf.SmoothDamp(transform.position.z, playerPosition2.position.z - 5.33f, ref z, smoothTime);
                cameraNextPosition.y = Mathf.SmoothDamp(transform.position.y, playerPosition2.position.y + 5.33f, ref y, smoothTime);
            }
           
            //SmoothCam.orthographicSize = Mathf.SmoothDamp(SmoothCam.orthographicSize, 5, ref y, smoothTime);


            transform.position = cameraNextPosition;
        }
    }
}