using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraImageRendering : MonoBehaviour
{
    #region serialize field
    [SerializeField, Header("カメラから取得した映像を表示する")]
    private RawImage rawImage;
    #endregion

    #region private field
    private WebCamTexture webCam;  //Webカメラ
    #endregion

    #region Unity function
    // Update is called once per frame
    void Start()
    {
        // WebCamTextureのインスタンスを生成
        webCam = new WebCamTexture();
        //RawImageのテクスチャにWebCamTextureのインスタンスを設定
        rawImage.texture = webCam;
        //カメラ表示開始
        webCam.Play();
    }
    #endregion
}
