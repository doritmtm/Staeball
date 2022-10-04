using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCylinderCollisionHandler : MonoBehaviour
{
    private GameObject winCanvas;
    public GameObject playerBall;
    // Start is called before the first frame update
    void Start()
    {
        winCanvas = GameObject.Find("WinCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.Equals(playerBall))
        {
            Vector3 distance = other.gameObject.transform.position - gameObject.transform.position;
            float startTime = GameStatus.startTime;
            int timeElapsed;
            if (distance.magnitude <= 1.15f)
            {
                winCanvas.GetComponent<Canvas>().enabled = true;
                playerBall.GetComponent<Rigidbody>().isKinematic = true;
                playerBall.GetComponent<Rigidbody>().isKinematic = false;
                timeElapsed = (int)(Time.time - startTime);
                int mins, secs;
                mins = timeElapsed / 60;
                secs = timeElapsed - mins * 60;
                string minsOut,secsOut;
                if(mins<10)
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
                GameObject.Find("TimeTextWin").GetComponent<Text>().text = "Time: " + minsOut + ":" + secsOut;
                Time.timeScale = 0;
            }
        }
    }
}
