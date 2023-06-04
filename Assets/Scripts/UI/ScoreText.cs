using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    #region serialize field
    /// <summary> �X�R�A��\�L����e�L�X�g </summary>
    [SerializeField, Header("�X�R�A�e�L�X�g")]
    private Text scoreText;
    #endregion

    #region Unity function
    void Update()
    {
        scoreText.text = GameMaster.instance.gameScore.ToString();
    }
    #endregion
}
