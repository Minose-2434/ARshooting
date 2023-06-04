using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    #region private field
    /// <summary>
    /// 弾が生成されてからの経過時間
    /// </summary>
    private float timer;
    #endregion

    #region Unity function
    // Update is called once per frame
    void Update()
    {
        //経過時間を足していく
        timer += Time.deltaTime;

        //生成されてから1秒後にオブジェクト削除
        if(timer >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
