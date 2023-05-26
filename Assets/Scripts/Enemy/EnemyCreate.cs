using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    #region serialize field
    /// <summary> 敵の親オブジェクト </summary>
    [SerializeField, Header("敵の親オブジェクト")]
    private GameObject enemysPrefab;
    /// <summary> 敵1のプレハブ </summary>
    [SerializeField, Header("敵1のプレハブ")]
    private GameObject enemyOnePrefab;
    /// <summary> 敵2のプレハブ </summary>
    [SerializeField, Header("敵2のプレハブ")]
    private GameObject enemyTwoPrefab;
    /// <summary> 敵3のプレハブ </summary>
    [SerializeField, Header("敵3のプレハブ")]
    private GameObject enemyThreePrefab;
    #endregion

    #region private field
    /// <summary> 敵生成を制御するための時間 </summary>
    private float enemyTimer;
    /// <summary> 敵生成をする時間 </summary>
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
    /// スコアに応じて敵生成を行うメソッド
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
                    //敵の生成
                    Create(enemyOnePrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 1:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //敵の生成
                    Create(enemyTwoPrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 2:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //敵の生成
                    Create(enemyThreePrefab);
                    GameMaster.instance.enemyNum += 1;
                    enemyTimer = 0;
                }
                break;
            case 3:
                if (_enemyNum == 0 || enemyTimer > createTime)
                {
                    //敵の生成
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
                    //敵の生成
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
    /// ランダムな座標にオブジェクトを生成するメソッド
    /// </summary>
    /// <param name="enemyKind"> 生成するオブジェクトのプレハブ </param>
    private void Create(GameObject enemyKind)
    {
        GameObject _enemy = Instantiate(enemyKind, enemysPrefab.transform);
        _enemy.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 10f);
        _enemy.transform.LookAt(Vector3.zero);
    }
    #endregion
}
