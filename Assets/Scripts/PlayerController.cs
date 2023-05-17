using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;  //�e�e�̃v���n�u

    [SerializeField]
    private GameObject camera;   //���݂̌������擾����ׂ̃J����

    public Quaternion baseQuaternion;

    void Start()
    {
        Input.gyro.enabled = true;
        CameraReset();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotate();

        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        //�J�����̌����ƈʒu���擾
        Quaternion _qua = camera.transform.rotation;
        Vector3 _pos = camera.transform.position;

        //�Q�[���I�u�W�F�N�g�𐶐�
        GameObject _bullet = Instantiate(bulletPrefab, _pos, _qua);

        //�͂�^���Č���
        Rigidbody _rb = _bullet.GetComponent<Rigidbody>();  // rigidbody���擾
        _rb.AddRelativeForce(Vector3.forward * 3f, ForceMode.Impulse);          // �͂�������
    }

    private void CameraRotate()
    {
        Quaternion _androidRotate = Quaternion.identity;
        _androidRotate.x = -Input.gyro.attitude.x;
        _androidRotate.y = -Input.gyro.attitude.y;
        _androidRotate.z = Input.gyro.attitude.z;
        _androidRotate.w = Input.gyro.attitude.w;

        camera.transform.localRotation = Quaternion.Inverse(baseQuaternion) * _androidRotate;

    }

    public void CameraReset()
    {
        baseQuaternion.x = -Input.gyro.attitude.x;
        baseQuaternion.y = -Input.gyro.attitude.y;
        baseQuaternion.z = Input.gyro.attitude.z;
        baseQuaternion.w = Input.gyro.attitude.w;
    }
}
