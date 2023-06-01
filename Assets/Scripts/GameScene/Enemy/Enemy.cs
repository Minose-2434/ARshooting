using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region serialize field
    /// <summary> 倒した時にもらえるスコア </summary>
    [SerializeField, Header("スコア")]
    private int enemyScore;
    /// <summary> 正面方向の速度 </summary>
    [SerializeField, Header("前方速度")]
    private float frontSpeed;
    /// <summary> 左右方向の速度 </summary>
    [SerializeField, Header("左右速度")]
    private float rightSpeed;
    /// <summary> 上下方向の速度 </summary>
    [SerializeField, Header("上下速度")]
    private float upSpeed;
    #endregion

    #region private field
    /// <summary> 動きを制御するためのタイマー </summary>
    private float enemyTimer;
    #endregion

    #region Unity function
    // Update is called once per frame
    void Update()
    {
        if(GameMaster.instance.gameState == GameMaster.GAME_STATE.Play)
        {
            Move();
        }
    }

    /// <summary>
    /// 弾が当たった時スコアを足して消える
    /// </summary>
    /// <param name="collision"> 当たった物のcollision </param>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameMaster.instance.gameScore += enemyScore;
            Destroy(collision.gameObject);
            GameMaster.instance.enemyNum -= 1;
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// 敵をパラメータに沿って動かす
    /// </summary>
    private void Move()
    {
        enemyTimer += Time.deltaTime;
        Vector3 _speed = new Vector3();
        float _sin = Mathf.Sin(2 * Mathf.PI * enemyTimer * 0.5f + Mathf.PI / 2);
        _speed += this.transform.forward * frontSpeed + this.transform.right * rightSpeed * _sin + this.transform.up * upSpeed * _sin;
        this.transform.position += _speed * Time.deltaTime;
        if(this.transform.position.z < 0)
        {
            GameMaster.instance.gameState = GameMaster.GAME_STATE.Lose;
            Destroy(this.gameObject);
        }
    }
    #endregion
}
