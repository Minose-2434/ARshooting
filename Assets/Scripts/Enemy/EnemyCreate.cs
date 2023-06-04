using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    #region serialize field
    /// <summary> �G�̐e�I�u�W�F�N�g </summary>
    [SerializeField, Header("�G�̐e�I�u�W�F�N�g")]
    private GameObject enemysPrefab;
    /// <summary> �G1�̃v���n�u </summary>
    [SerializeField, Header("�G1�̃v���n�u")]
    private GameObject enemyOnePrefab;
    /// <summary> �G2�̃v���n�u </summary>
    [SerializeField, Header("�G2�̃v���n�u")]
    private GameObject enemyTwoPrefab;
    /// <summary> �G3�̃v���n�u </summary>
    [SerializeField, Header("�G3�̃v���n�u")]
    private GameObject enemyThreePrefab;
    #endregion

    #region private field
    /// <summary> �G�����𐧌䂷�邽�߂̎��� </summary>
    private float enemyTimer;
    /// <summary> �G���������鎞�� </summary>
    private float createTime = 1.0f;
    #endregion

    #region Unity function
    // Update is called once per frame
    void Update()
    {
        if(GameMaster.instance.gameState == GameMaster.GAME_STATE.Play)
        {
            CreateManager();
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// �X�R�A�ɉ����ēG�������s�����\�b�h
    /// </summary>
    private void CreateManager()
    {
        enemyTimer += Time.deltaTime;
        int _score = GameMaster.instance.gameScore;
        int _enemyNum = GameMaster.instance.enemyNum;
        switch (_score / 1000)
        {
            case 0:
                if(_enemyNum == 0 || enemyTimer > createTime)
                {
                    //�G�̐���
                    Create(enemyOnePrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 1:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //�G�̐���
                    Create(enemyTwoPrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 2:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //�G�̐���
                    Create(enemyThreePrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 3:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //�G�̐���
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            Create(enemyOnePrefab);
                            break;
                        case 1:
                            Create(enemyTwoPrefab);
                            break;
                        case 2:
                            Create(enemyThreePrefab);
                            break;
                    }
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            default:
                if (_enemyNum == 0 || enemyTimer > createTime/2)
                {
                    //�G�̐���
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            Create(enemyOnePrefab);
                            break;
                        case 1:
                            Create(enemyTwoPrefab);
                            break;
                        case 2:
                            Create(enemyThreePrefab);
                            break;
                    }
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
        }
    }

    /// <summary>
    /// �����_���ȍ��W�ɃI�u�W�F�N�g�𐶐����郁�\�b�h
    /// </summary>
    /// <param name="enemyKind"> ��������I�u�W�F�N�g�̃v���n�u </param>
    private void Create(GameObject enemyKind)
    {
        GameObject _enemy = Instantiate(enemyKind, enemysPrefab.transform);
        _enemy.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 10f);
        _enemy.transform.LookAt(Vector3.zero);
    }
    #endregion
}
