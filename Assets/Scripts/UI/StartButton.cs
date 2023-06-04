using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    #region serialize field
    /// <summary> キャンバスオブジェクト </summary>
    [SerializeField, Header("キャンバスオブジェクト")]
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
