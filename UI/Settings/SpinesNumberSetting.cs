using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpinesNumberSetting : MonoBehaviour
{
    public GameObject inputText;
    public GameObject minusButton;
    public GameObject plusButton;
    // Start is called before the first frame update
    void Start()
    {
        inputText.GetComponent<InputField>().text = GameStatus.nrOfSpines.ToString();
        inputText.GetComponent<InputField>().onValueChanged.AddListener(delegate { onValueChangedEvent(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onValueChangedEvent()
    {
        GameStatus.nrOfSpines = int.Parse(inputText.GetComponent<InputField>().text);
    }
}
