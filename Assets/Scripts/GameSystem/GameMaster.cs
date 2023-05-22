using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    #region define
    /// <summary> �Q�[���̏�� </summary>
    public enum GAME_STATE
    {
        /// <summary> �Q�[���ҋ@��� </summary>
        StandBy,
        /// <summary> �Q�[���X�^�[�g��� </summary>
        Start,
        /// <summary> �Q�[���v���C��� </summary>
        Play,
        /// <summary> �Q�[�����f��� </summary>
        Pose,
        /// <summary> �Q�[���I�[�o�[��� </summary>
        Lose,
    }
    #endregion

    #region serialize field
    /// <summary> �J�E���g�_�E����\�L����e�L�X�g </summary>
    [SerializeField, Header("�J�E���g�_�E���e�L�X�g")]
    private Text countText;
    /// <summary> �X�R�A��\�L����e�L�X�g </summary>
    [SerializeField, Header("�X�R�A�e�L�X�g")]
    private Text scoreText;
    /// <summary> ����������Canvas </summary>
    [SerializeField, Header("LoseCanvas")]
    private GameObject loseCanvas;
    #endregion

    #region public field
    public static GameMaster instance;
    /// <summary> �Q�[���̌o�ߎ��� </summary>
    public float gameTimer;
    /// <summary> �Q�[���X�R�A </summary>
    public int gameScore;
    /// <summary> �G�L�����̐� </summary>
    public int enemyNum;
    /// <summary> �Q�[���̏�� </summary>
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
            //�ҋ@��Ԃ̏���
            case GAME_STATE.StandBy:
                break;
            //�Q�[���J�E���g�_�E��
            case GAME_STATE.Start:
                gameTimer += Time.deltaTime;
                CountDown();
                break;
            //�Q�[���v���C���
            case GAME_STATE.Play:
                ScoreUpdate();
                break;
            //�Q�[�����f
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
    /// �Q�[���J�n�O�̃J�E���g�_�E�����s�����\�b�h
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
    /// �X�R�A��\�����郁�\�b�h
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
