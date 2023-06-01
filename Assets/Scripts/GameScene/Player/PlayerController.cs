using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region serialize field
    /// <summary> 弾のプレハブ </summary>
    [SerializeField, Header("弾のプレハブ")]
    private GameObject bulletPrefab;
    /// <summary> カメラオブジェクト </summary>
    [SerializeField, Header("カメラオブジェクト")]
    private GameObject playerCamera;

    #endregion

    #region private field
    /// <summary>
    /// 基準となる回転角
    /// </summary>
    private Quaternion baseQuaternion;    
    #endregion

    #region Unity function
    void Start()
    {
        Input.gyro.enabled = true;
        CameraReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.instance.gameState == GameMaster.GAME_STATE.Play)
        {
            CameraRotate();

            if (Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// 画面をタップした際に弾を打ち出すメソッド
    /// </summary>
    private void Shooting()
    {
        //カメラの位置と回転を参照
        Quaternion _qua = playerCamera.transform.rotation;
        Vector3 _pos = playerCamera.transform.position;

        //弾の生成
        GameObject _bullet = Instantiate(bulletPrefab, _pos, _qua);

        //力を加える
        Rigidbody _rb = _bullet.GetComponent<Rigidbody>();  
        _rb.AddRelativeForce(Vector3.forward * 3f, ForceMode.Impulse);          
    }

    /// <summary>
    /// Androidの回転に合わせてゲーム内カメラを回転させるメソッド
    /// </summary>
    private void CameraRotate()
    {
        Quaternion _androidRotate = Quaternion.identity;
        _androidRotate.x = -Input.gyro.attitude.x;
        _androidRotate.y = -Input.gyro.attitude.y;
        _androidRotate.z = Input.gyro.attitude.z;
        _androidRotate.w = Input.gyro.attitude.w;

        GetComponent<Camera>().transform.localRotation = Quaternion.Inverse(baseQuaternion) * _androidRotate;
    }
    #endregion

    #region public function
    /// <summary>
    /// 基準を現在の回転角にするメソッド
    /// </summary>
    public void CameraReset()
    {
        baseQuaternion.x = -Input.gyro.attitude.x;
        baseQuaternion.y = -Input.gyro.attitude.y;
        baseQuaternion.z = Input.gyro.attitude.z;
        baseQuaternion.w = Input.gyro.attitude.w;
    }
    #endregion
}
