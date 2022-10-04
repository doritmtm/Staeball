using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinesCollisionHandler : MonoBehaviour
{
    public GameObject playerBall;
    public Texture lifeFull;
    public Texture lifeEmpty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 playerPos,collDirection;
        float startTime = GameStatus.startTime;
        int timeElapsed;
        if (collision.gameObject.Equals(playerBall))
        {
            if (GameStatus.nrLives > 1)
            {
                playerPos = playerBall.transform.position;
                collDirection = (playerPos - gameObject.transform.position).normalized;
                playerPos.y += 20f;
                playerPos += collDirection * 0.8f;
                playerBall.transform.position = playerPos;
                GameStatus.mainCamera.GetComponent<GyroscopeGravityChanger>().enabled = false;
                GameStatus.mainCamera.GetComponent<EnableGyroscopeGravityChangerOnTouchDown>().enabled = true;
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            playerBall.GetComponent<Rigidbody>().isKinematic = true;
            playerBall.GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("Life" + GameStatus.nrLives).GetComponent<RawImage>().texture = lifeEmpty;
            GameStatus.nrLives--;
            if(GameStatus.nrLives<=0)
            {
                //LOST!!
                GameObject.Find("LoseCanvas").GetComponent<Canvas>().enabled = true;
                timeElapsed = (int)(Time.time - startTime);
                int mins, secs;
                mins = timeElapsed / 60;
                secs = timeElapsed - mins * 60;
                string minsOut, secsOut;
                if (mins < 10)
                {
                    minsOut = "0" + mins;
                }
                else
                {
                    minsOut = mins.ToString();
                }
                if (secs < 10)
                {
                    secsOut = "0" + secs;
                }
                else
                {
                    secsOut = secs.ToString();
                }
                GameObject.Find("TimeTextLose").GetComponent<Text>().text = "Time: " + minsOut + ":" + secsOut;
                Time.timeScale = 0;
            }
        }
    }
}
