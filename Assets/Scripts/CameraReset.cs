using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;   //�J�����I�u�W�F�N�g

    private PlayerController palyerController;

    public void OnClickCameraReset()
    {
        palyerController = camera.GetComponent<PlayerController>();
        palyerController.CameraReset();
    }
}
