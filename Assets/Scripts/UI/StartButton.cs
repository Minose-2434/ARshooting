using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    #region serialize field
    /// <summary> �L�����o�X�I�u�W�F�N�g </summary>
    [SerializeField, Header("�L�����o�X�I�u�W�F�N�g")]
    private GameObject startCanvas;
    #endregion

    #region Unity function
    public void OnClickStartButton()
    {
        GameMaster.instance.gameState = GameMaster.GAME_STATE.Start;
        Destroy(startCanvas);
    }
    #endregion
}
