using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// �̱��� �������� �ұ� �����~
public class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;
    
    //camera�� Ȱ��ȭ �� ī�޶�����.
    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    // ī�޶� �ٲ۴�. �Ű����� camera�� �ٲ� ī�޶�.
    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach(CinemachineVirtualCamera c in cameras)
        {
            // ������ ī�޶���� Priority�� �����ش�.
            if(c!= camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }  

    // ī�޶� ���, ����� ī�޶�� ������ �� ����.
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera registerd: " + camera);
    }

    // ī�޶� ��� ����
    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera Unregisterd: " + camera);
    }
}
