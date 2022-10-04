using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeGravityChanger : MonoBehaviour
{
    Gyroscope gyro;
    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 correctGravity;
        correctGravity.x = -gyro.gravity.y;
        correctGravity.y = gyro.gravity.z;
        if (correctGravity.y >= 0.0f)
        {
            correctGravity.y = -0.1f;
        }
        correctGravity.z = gyro.gravity.x;
        Physics.gravity = 9.81f * correctGravity;
    }
}
