using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    #region private field
    /// <summary>
    /// �e����������Ă���̌o�ߎ���
    /// </summary>
    private float timer;
    #endregion

    #region Unity function
    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԃ𑫂��Ă���
        timer += Time.deltaTime;

        //��������Ă���1�b��ɃI�u�W�F�N�g�폜
        if(timer >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
