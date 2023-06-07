using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasyState : MonoBehaviour
{
    #region private field
    /// <summary> 敵キャラクターを移動させるクラス </summary>
    public Enemy enemy;
    /// <summary> ステータス変更を一秒だけにするためのbool </summary>
    private bool change;
    /// <summary> 元の移動ステータスを保持しておく変数 </summary>
    private float moveState;
    #endregion

    #region Unity function

    void Start()
    {
        change = false;
        enemy = this.gameObject.GetComponent<Enemy>();  //Enemyクラスを取得
        moveState = enemy.frontSpeed;                   //移動ステータスを保存

        //4000点以上の時ステータス変更を確率で行う
        if (GameMaster.instance.gameScore >= 4000)
        {
            InvokeRepeating("StateChange", 0, 0.3f);
        }
    }
    #endregion

    #region private function
    /// <summary> 確率で移動ステータスを変更するメソッド </summary>
    private void StateChange()
    {
        if (change)
        {
            enemy.frontSpeed = moveState;
            change = false;
        }
        else if(Random.Range(0f, 1f) < (GameMaster.instance.gameScore - 3000) / 10000)
        {
            enemy.frontSpeed = moveState + Random.Range(5, 10);
            change = true;
        }
    }
    #endregion

}
