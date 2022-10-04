using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
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
        gameObject.GetComponentInParent<Canvas>().enabled = false;
        GameStatus.mainCamera.GetComponent<GridBasedMapGenerator>().clearMap();
        GameStatus.mainCamera.GetComponent<GridBasedMapGenerator>().generateMap();
        Time.timeScale = 1;
    }
}
