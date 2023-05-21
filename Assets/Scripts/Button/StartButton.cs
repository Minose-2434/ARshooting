using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    #region serialize field
    /// <summary> カメラオブジェクト </summary>
    [SerializeField, Header("カメラオブジェクト")]
    private GameObject playerCamera;
    /// <summary> キャンバスオブジェクト </summary>
    [SerializeField, Header("キャンバスオブジェクト")]
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
