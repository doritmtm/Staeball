using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputGyroExample : MonoBehaviour
{
    Gyroscope gyro;
    public Text text1, text2, text3, text4;
    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    //This is a legacy function, check out the UI section for other ways to create your UI
    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        //GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        //GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude.eulerAngles);
        //GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
        //text1.text = "Gyro rotation rate " + gyro.rotationRate;
        //text2.text = "Gyro attitude" + m_Gyro.attitude.eulerAngles;
        //text3.text = "Gyro enabled : " + m_Gyro.enabled;
        Quaternion rot = gyro.attitude;
        Vector3 gyroAngles = gyro.attitude.eulerAngles;
        Vector3 gyroCorrectAngles;
        gyroCorrectAngles.x = gyroAngles.y;
        gyroCorrectAngles.y = 360.0f - gyroAngles.z;
        gyroCorrectAngles.z = 360.0f - gyroAngles.x;
        Vector3 rotAngles=gyroCorrectAngles;
        //rotAngles.z = 0.0f;
        //rotAngles.x = -gyroAngles.y;
        //rotAngles.y = gyroAngles.z - 90.0f;
        //rotAngles.y = 0.0f;
        //rotAngles.z = -gyroAngles.x;
        rot.eulerAngles = rotAngles;
        //Physics.gravity = 9.81f * (rot * Vector3.down);
        Vector3 correctGravity;
        correctGravity.x = -gyro.gravity.y;
        correctGravity.y = gyro.gravity.z;
        if(correctGravity.y >= 0.0f)
        {
            correctGravity.y = 0.0f;
        }
        correctGravity.z = gyro.gravity.x;
        Physics.gravity = 9.81f * correctGravity;
        text1.text = "Gyro Correct Angles: " + gyroCorrectAngles;
        text2.text = "Gyro attitude: " + gyro.attitude.eulerAngles;
        text3.text = "Rot: " + rot.eulerAngles;
        text4.text = "Physics gravity: " + Physics.gravity;
    }
}
