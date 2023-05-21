using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraImageRendering : MonoBehaviour
{
    #region serialize field
    [SerializeField, Header("�J��������擾�����f����\������")]
    private RawImage rawImage;
    #endregion

    #region private field
    private WebCamTexture webCam;  //Web�J����
    #endregion

    #region Unity function
    // Update is called once per frame
    void Start()
    {
        // WebCamTexture�̃C���X�^���X�𐶐�
        webCam = new WebCamTexture();
        //RawImage�̃e�N�X�`����WebCamTexture�̃C���X�^���X��ݒ�
        rawImage.texture = webCam;
        //�J�����\���J�n
        webCam.Play();
    }
    #endregion
}
