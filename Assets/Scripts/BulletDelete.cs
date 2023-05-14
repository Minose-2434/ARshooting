using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1.0f)
        {
            Debug.Log(this.transform.position.z);
            Destroy(this.gameObject);
        }
    }
}
