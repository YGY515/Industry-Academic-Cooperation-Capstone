using UnityEngine;
using Cinemachine;
public class CameraRegister : MonoBehaviour
{
    // 현재 카메라를 등록한다.
    private void OnEnable()
    {
        CameraSwitcher.Register(GetComponent<CinemachineVirtualCamera>());
    }

    // 등록을 해제한다.
    private void OnDisable()
    {
        CameraSwitcher.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}

