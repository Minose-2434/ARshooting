using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    #region serialize field
    /// <summary> スコアを表記するテキスト </summary>
    [SerializeField, Header("スコアテキスト")]
    private Text scoreText;
    #endregion

    #region Unity function
    void Update()
    {
        scoreText.text = GameMaster.instance.gameScore.ToString();
    }
    #endregion
}
