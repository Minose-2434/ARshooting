using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;  //銃弾のプレハブ

    [SerializeField]
    private GameObject camera;   //現在の向きを取得する為のカメラ

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        //カメラの向きと位置を取得
        Quaternion _qua = camera.transform.rotation;
        Vector3 _pos = camera.transform.position;

        //ゲームオブジェクトを生成
        GameObject _bullet = Instantiate(bulletPrefab, _pos, _qua);

        //力を与えて撃つ
        Rigidbody _rb = _bullet.GetComponent<Rigidbody>();  // rigidbodyを取得
        _rb.AddRelativeForce(Vector3.forward * 3f, ForceMode.Impulse);          // 力を加える
    }
}
