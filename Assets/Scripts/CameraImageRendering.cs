using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraImageRendering : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage;  //カメラから取得した映像を表示する

    WebCamTexture webCam;  //Webカメラ

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
}
