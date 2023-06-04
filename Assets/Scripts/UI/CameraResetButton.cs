using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetButton : MonoBehaviour
{
    #region serialize field
    [SerializeField, Header("カメラオブジェクト")]
    private GameObject playerCamera;
    #endregion

    #region Unity function
    public void OnClickCameraReset()
    {
        playerCamera.GetComponent<PlayerController>().CameraReset();
    }
    #endregion
}
