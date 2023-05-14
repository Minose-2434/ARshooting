using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraImageRendering : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage;  //�J��������擾�����f����\������

    WebCamTexture webCam;  //Web�J����

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
}
