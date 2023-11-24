using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// 싱글톤 패턴으로 할까 고민중~
public class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;
    
    //camera가 활성화 된 카메라인지.
    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    // 카메라를 바꾼다. 매개변수 camera는 바꿀 카메라.
    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach(CinemachineVirtualCamera c in cameras)
        {
            // 나머지 카메라들의 Priority를 낮춰준다.
            if(c!= camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }  

    // 카메라 등록, 등록한 카메라는 관리할 수 있음.
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera registerd: " + camera);
    }

    // 카메라 등록 해제
    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera Unregisterd: " + camera);
    }
}
