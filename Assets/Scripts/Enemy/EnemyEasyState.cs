using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasyState : MonoBehaviour
{
    #region private field
    /// <summary> �G�L�����N�^�[���ړ�������N���X </summary>
    public Enemy enemy;
    /// <summary> �X�e�[�^�X�ύX����b�����ɂ��邽�߂�bool </summary>
    private bool change;
    /// <summary> ���̈ړ��X�e�[�^�X��ێ����Ă����ϐ� </summary>
    private float moveState;
    #endregion

    #region Unity function

    void Start()
    {
        change = false;
        enemy = this.gameObject.GetComponent<Enemy>();  //Enemy�N���X���擾
        moveState = enemy.frontSpeed;                   //�ړ��X�e�[�^�X��ۑ�

        //4000�_�ȏ�̎��X�e�[�^�X�ύX���m���ōs��
        if (GameMaster.instance.gameScore >= 4000)
        {
            InvokeRepeating("StateChange", 0, 0.3f);
        }
    }
    #endregion

    #region private function
    /// <summary> �m���ňړ��X�e�[�^�X��ύX���郁�\�b�h </summary>
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
