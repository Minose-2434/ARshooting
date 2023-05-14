using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;  //�e�e�̃v���n�u

    [SerializeField]
    private GameObject camera;   //���݂̌������擾����ׂ̃J����

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
        //�J�����̌����ƈʒu���擾
        Quaternion _qua = camera.transform.rotation;
        Vector3 _pos = camera.transform.position;

        //�Q�[���I�u�W�F�N�g�𐶐�
        GameObject _bullet = Instantiate(bulletPrefab, _pos, _qua);

        //�͂�^���Č���
        Rigidbody _rb = _bullet.GetComponent<Rigidbody>();  // rigidbody���擾
        _rb.AddRelativeForce(Vector3.forward * 3f, ForceMode.Impulse);          // �͂�������
    }
}
