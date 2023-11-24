using UnityEngine;
using Cinemachine;
public class CameraRegister : MonoBehaviour
{
    // ���� ī�޶� ����Ѵ�.
    private void OnEnable()
    {
        CameraSwitcher.Register(GetComponent<CinemachineVirtualCamera>());
    }

    // ����� �����Ѵ�.
    private void OnDisable()
    {
        CameraSwitcher.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}

