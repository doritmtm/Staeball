using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
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
        GameStatus.mainCamera.GetComponent<GridBasedMapGenerator>().replayMap();
        Time.timeScale = 1;
    }
}
