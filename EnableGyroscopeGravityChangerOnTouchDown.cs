using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGyroscopeGravityChangerOnTouchDown : MonoBehaviour
{
    public GameObject playerBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerBall.transform.position.y<=0.9f)
        {
            gameObject.GetComponent<GyroscopeGravityChanger>().enabled = true;
            gameObject.GetComponent<EnableGyroscopeGravityChangerOnTouchDown>().enabled = false;
        }
    }
}
