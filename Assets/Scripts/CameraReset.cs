using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;   //カメラオブジェクト

    private PlayerController palyerController;

    public void OnClickCameraReset()
    {
        palyerController = camera.GetComponent<PlayerController>();
        palyerController.CameraReset();
    }
}
