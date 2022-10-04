using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTweakerButton : MonoBehaviour
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
        GameStatus.openedUI = gameObject.GetComponentInParent<Canvas>();
        GameObject.Find("LevelTweakerCanvas").GetComponent<Canvas>().enabled = true;
    }
}
