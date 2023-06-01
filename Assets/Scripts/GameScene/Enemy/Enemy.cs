using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region serialize field
    /// <summary> �|�������ɂ��炦��X�R�A </summary>
    [SerializeField, Header("�X�R�A")]
    private int enemyScore;
    /// <summary> ���ʕ����̑��x </summary>
    [SerializeField, Header("�O�����x")]
    private float frontSpeed;
    /// <summary> ���E�����̑��x </summary>
    [SerializeField, Header("���E���x")]
    private float rightSpeed;
    /// <summary> �㉺�����̑��x </summary>
    [SerializeField, Header("�㉺���x")]
    private float upSpeed;
    #endregion

    #region private field
    /// <summary> �����𐧌䂷�邽�߂̃^�C�}�[ </summary>
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
    /// �e�������������X�R�A�𑫂��ď�����
    /// </summary>
    /// <param name="collision"> ������������collision </param>
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
    /// �G���p�����[�^�ɉ����ē�����
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
