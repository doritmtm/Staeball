using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static int nrLives;
    public static float startTime;
    public static GameObject mainCamera;
    public static bool initMapActive = true;
    public static float spinesGenerateChance=0.2f;
    public static int nrOfSpines = 100;
    public static int gridWidth = 30;
    public static int gridHeight = 25;
    public static Canvas openedUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowInitMap()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("initMap"))
        {
            g.SetActive(true);
        }
        initMapActive = true;
    }

    public static void HideInitMap()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("initMap"))
        {
            g.SetActive(false);
        }
        initMapActive = false;
    }
}
