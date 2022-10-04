using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBallWithCamera : MonoBehaviour
{
    public GameObject ball;
    private Vector3 initialBallPos;
    // Start is called before the first frame update
    void Start()
    {
        initialBallPos = ball.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 diff=ball.transform.position - initialBallPos;
        gameObject.transform.position += diff;
        initialBallPos = ball.transform.position;
    }
}
