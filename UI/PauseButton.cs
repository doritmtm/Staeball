using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onClick()
    {
        GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = true;
        float startTime = GameStatus.startTime;
        int timeElapsed;
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
        GameObject.Find("TimeTextPause").GetComponent<Text>().text = "Time: " + minsOut + ":" + secsOut;
        Time.timeScale = 0;
    }
}
