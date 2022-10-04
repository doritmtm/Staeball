using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinesGenerateChanceSetting : MonoBehaviour
{
    public GameObject slider;
    public GameObject valueText;
    // Start is called before the first frame update
    void Start()
    {
        int percentage=(int)(GameStatus.spinesGenerateChance*100);
        slider.GetComponent<Slider>().value = percentage;
        valueText.GetComponent<Text>().text = percentage.ToString()+"%";
        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate { valueChange(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void valueChange()
    {
        int percentage = (int)slider.GetComponent<Slider>().value;
        valueText.GetComponent<Text>().text = percentage.ToString()+"%";
        GameStatus.spinesGenerateChance = percentage / 100.0f;
    }
}
