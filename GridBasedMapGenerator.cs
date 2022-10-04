using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBasedMapGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject spinesPrefab;
    public GameObject winCylinderPrefab;
    public GameObject playerBall;
    private GameObject winCanvas;
    public Texture lifeFull;
    public Texture lifeEmpty;
    private float floorInScale = 100f;
    private float floorScale = 0.5f;
    private float spinesMaxScale = 1.0f;
    private float spinesMinScale = 0.4f;
    private float gridSize=2.0f;
    private int gridWidth;
    private int gridHeight;
    private GameObject floor;
    private Vector3 playerInitialPos;
    public GameObject[,] gridData;
    // Start is called before the first frame update
    void Start()
    {
        GameStatus.mainCamera = gameObject;
        winCanvas = GameObject.Find("WinCanvas");
        GameStatus.openedUI = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void generateMap()
    {
        int i, j, k;
        gridWidth = GameStatus.gridWidth;
        gridHeight = GameStatus.gridHeight;
        GameStatus.nrLives = 3;
        for(i=1;i<=3;i++)
        {
            GameObject.Find("Life" + i).GetComponent<RawImage>().texture=lifeFull;
        }
        floor = Instantiate(floorPrefab, new Vector3(-80f, 0f, 0f), Quaternion.identity);
        Vector3 floorScale;
        floorScale.z = gridWidth * gridSize / 100.0f;
        floorScale.y = 0.5f;
        floorScale.x = gridHeight * gridSize / 100.0f;
        floor.transform.localScale = floorScale;
        Vector3 spinePos;
        GameObject spines;
        float randomSpinesScale;
        Vector3 spineRot;
        float randomVal;
        int nrOfSpines = 0;
        //gridLength = (int)(48 * floorScale) + 1;
        gridData = new GameObject[gridWidth+1, gridHeight+1];
        int antiBlock=0;
        for (k = 0; k < GameStatus.nrOfSpines; k++)
        {
            antiBlock = 0;
            do
            {
                i = Random.Range(0, gridWidth - 1);
                j = Random.Range(0, gridHeight - 1);
                antiBlock++;
            }
            while (gridData[i, j] != null && antiBlock<100);
            spinePos = floor.transform.position;
            spinePos.z += gridSize * (i - (gridWidth - 1) / 2);
            spinePos.y += 0.3f;
            spinePos.x += gridSize * (j - (gridHeight - 1) / 2);
            spines = Instantiate(spinesPrefab, spinePos, Quaternion.identity);
            spines.GetComponentInChildren<SpinesCollisionHandler>().playerBall = playerBall;
            gridData[i, j] = spines;
            randomSpinesScale = Random.Range(spinesMinScale, spinesMaxScale);
            spines.transform.localScale *= randomSpinesScale;
            spinePos.z += Random.Range(0f, (spinesMaxScale - randomSpinesScale) / (spinesMaxScale - spinesMinScale) * 0.35f * gridSize);
            spinePos.x += Random.Range(0f, (spinesMaxScale - randomSpinesScale) / (spinesMaxScale - spinesMinScale) * 0.35f * gridSize);
            spines.transform.position = spinePos;
            spineRot = spines.transform.rotation.eulerAngles;
            spineRot.y = Random.Range(0f, 360f);
            spines.transform.rotation = Quaternion.Euler(spineRot);
        }
        antiBlock = 0;
        do
        {
            i = Random.Range(0, gridWidth - 1);
            j = Random.Range(0, gridHeight - 1);
        }
        while (gridData[i, j] != null && antiBlock < 100);
        Vector3 winPos;
        winPos = floor.transform.position;
        winPos.z += gridSize * (i - (gridWidth - 1) / 2);
        winPos.y += -0.4f;
        winPos.x += gridSize * (j - (gridHeight - 1) / 2);
        GameObject winCylinder;
        winCylinder = Instantiate(winCylinderPrefab, winPos, Quaternion.identity);
        winCylinder.GetComponentInChildren<WinCylinderCollisionHandler>().playerBall = playerBall;
        gridData[i, j] = winCylinder;
        antiBlock = 0;
        do
        {
            i = Random.Range(0, gridWidth - 1);
            j = Random.Range(0, gridHeight - 1);
        }
        while (gridData[i, j] != null && antiBlock < 100);
        Vector3 playerPos;
        playerPos = floor.transform.position;
        playerPos.z += gridSize * (i - (gridWidth - 1) / 2);
        playerPos.y += 20f;
        playerPos.x += gridSize * (j - (gridHeight - 1) / 2);
        playerBall.transform.position = playerPos;
        playerInitialPos = playerPos;
        Vector3 floorPos = floor.transform.position;
        floorPos.z -= 0.2f;
        floorPos.x -= 0.9f;
        floor.transform.position = floorPos;
        gameObject.GetComponent<GyroscopeGravityChanger>().enabled = false;
        gameObject.GetComponent<EnableGyroscopeGravityChangerOnTouchDown>().enabled = true;
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        playerBall.GetComponent<Rigidbody>().isKinematic = true;
        playerBall.GetComponent<Rigidbody>().isKinematic = false;
        GameStatus.startTime=Time.time;
    }
    public void clearMap()
    {
        int i, j;
        GameObject.Destroy(floor);
        for (i = 0; i < gridWidth; i++)
        {
            for (j = 0; j < gridHeight; j++)
            {
                GameObject.Destroy(gridData[i, j]);
            }
        }
    }
    public void replayMap()
    {
        int i, j;
        GameStatus.nrLives = 3;
        for (i = 1; i <= 3; i++)
        {
            GameObject.Find("Life" + i).GetComponent<RawImage>().texture = lifeFull;
        }
        playerBall.transform.position = playerInitialPos;
        playerBall.GetComponent<Rigidbody>().isKinematic = true;
        playerBall.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<GyroscopeGravityChanger>().enabled = false;
        gameObject.GetComponent<EnableGyroscopeGravityChangerOnTouchDown>().enabled = true;
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        GameStatus.startTime = Time.time;
    }
}
