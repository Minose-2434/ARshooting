using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    #region serialize field
    /// <summary> �J�����I�u�W�F�N�g </summary>
    [SerializeField, Header("�J�����I�u�W�F�N�g")]
    private GameObject playerCamera;
    /// <summary> �L�����o�X�I�u�W�F�N�g </summary>
    [SerializeField, Header("�L�����o�X�I�u�W�F�N�g")]
    private GameObject startCanvas;
    #endregion

    #region Unity function
    public void OnClickStartButton()
    {
        playerCamera.GetComponent<PlayerController>().CameraReset();
        GameMaster.instance.gameState = GameMaster.GAME_STATE.Start;
        Destroy(startCanvas);
    }
    #endregion
}
