using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectKeeper : MonoBehaviour
{
    #region serialize field
    [SerializeField, Header("�J�����I�u�W�F�N�g")]
    private Camera targetCamera;

    [SerializeField, Header("�ړI�𑜓x")]
    private Vector2 aspectVec;
    #endregion

    #region Unity function
    // Update is called once per frame
    void Update()
    {
        var screenAspect = Screen.width / (float)Screen.height; //��ʂ̃A�X�y�N�g��
        var targetAspect = aspectVec.x / aspectVec.y; //�ړI�̃A�X�y�N�g��

        var magRate = targetAspect / screenAspect; //�ړI�A�X�y�N�g��ɂ��邽�߂̔{��

        var viewportRect = new Rect(0, 0, 1, 1); //Viewport�����l��Rect���쐬

        if (magRate < 1)
        {
            viewportRect.width = magRate; //�g�p���鉡����ύX
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;//������
        }
        else
        {
            viewportRect.height = 1 / magRate; //�g�p����c����ύX
            viewportRect.y = 0.5f - viewportRect.height * 0.5f;//������
        }

        targetCamera.rect = viewportRect; //�J������Viewport�ɓK�p
    }
    #endregion
}