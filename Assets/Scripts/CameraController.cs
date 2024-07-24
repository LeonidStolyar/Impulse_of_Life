using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Start() {
        SetPlayerCameraFollow();
    }

    public void SetPlayerCameraFollow() {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineVirtualCamera == null) return;

        cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
    }
}
