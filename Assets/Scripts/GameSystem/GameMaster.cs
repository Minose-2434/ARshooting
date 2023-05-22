using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    #region define
    /// <summary> ゲームの状態 </summary>
    public enum GAME_STATE
    {
        /// <summary> ゲーム待機状態 </summary>
        StandBy,
        /// <summary> ゲームスタート状態 </summary>
        Start,
        /// <summary> ゲームプレイ状態 </summary>
        Play,
        /// <summary> ゲーム中断状態 </summary>
        Pose,
        /// <summary> ゲームオーバー状態 </summary>
        Lose,
    }
    #endregion

    #region serialize field
    /// <summary> カウントダウンを表記するテキスト </summary>
    [SerializeField, Header("カウントダウンテキスト")]
    private Text countText;
    /// <summary> スコアを表記するテキスト </summary>
    [SerializeField, Header("スコアテキスト")]
    private Text scoreText;
    /// <summary> 負けた時のCanvas </summary>
    [SerializeField, Header("LoseCanvas")]
    private GameObject loseCanvas;
    #endregion

    #region public field
    public static GameMaster instance;
    /// <summary> ゲームの経過時間 </summary>
    public float gameTimer;
    /// <summary> ゲームスコア </summary>
    public int gameScore;
    /// <summary> 敵キャラの数 </summary>
    public int enemyNum;
    /// <summary> ゲームの状態 </summary>
    public GAME_STATE gameState = GAME_STATE.StandBy;
    #endregion

    #region Unity function
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            //待機状態の処理
            case GAME_STATE.StandBy:
                break;
            //ゲームカウントダウン
            case GAME_STATE.Start:
                gameTimer += Time.deltaTime;
                CountDown();
                break;
            //ゲームプレイ状態
            case GAME_STATE.Play:
                ScoreUpdate();
                break;
            //ゲーム中断
            case GAME_STATE.Pose:
                break;
            case GAME_STATE.Lose:
                LoseCanvasCreate();
                break;
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// ゲーム開始前のカウントダウンを行うメソッド
    /// </summary>
    private void CountDown()
    {
        int _count = 3 - (int)gameTimer;
        if(_count > 0)
        {
            countText.text = _count.ToString();
        }
        else if (_count > -1)
        {
            countText.text = "Start";
        }
        else
        {
            countText.text = "";
            gameTimer = 0;
            gameState = GAME_STATE.Play;
        }
    }

    /// <summary>
    /// スコアを表示するメソッド
    /// </summary>
    private void ScoreUpdate()
    {
        scoreText.text = gameScore.ToString();
    }

    private void LoseCanvasCreate()
    {
        GameObject _canvas = Instantiate(loseCanvas, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        gameState = GAME_STATE.Pose;
    }
    #endregion
}
