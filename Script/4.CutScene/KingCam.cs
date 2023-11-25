using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCam : MonoBehaviour
{
    //private Camera SmoothCam;
    public Transform KingPosition;
    Vector3 cameraNextPosition;
    public float smoothTime = 0.1f;
    float x = .0f, y = .0f, z = .0f;

    [SerializeField]
    private float camAngle = 25.0f;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        if (KingPosition != null)
        {
            cameraNextPosition = transform.position;
            
            cameraNextPosition.x = Mathf.SmoothDamp(transform.position.x, KingPosition.position.x, ref x, smoothTime);
            cameraNextPosition.z = Mathf.SmoothDamp(transform.position.z, KingPosition.position.z - 8.33f, ref z, smoothTime);
            cameraNextPosition.y = Mathf.SmoothDamp(transform.position.y, KingPosition.position.y + 4.2f, ref y, smoothTime);

           
            //SmoothCam.orthographicSize = Mathf.SmoothDamp(SmoothCam.orthographicSize, 5, ref y, smoothTime);


            transform.position = cameraNextPosition;
        }
    }
}