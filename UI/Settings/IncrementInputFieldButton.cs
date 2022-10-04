using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;
using System.Threading.Tasks;

public class IncrementInputFieldButton : MonoBehaviour
{
    public GameObject inputField;
    private bool shouldStop = false;
    public int maximum;
    // Start is called before the first frame update
    void Start()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener(delegate { onPointerDownEvent(); });
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener(delegate { onPointerUpEvent(); });
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void onPointerDownEvent()
    {
        inputField.GetComponent<InputField>().text = 30.ToString();
        Thread.Sleep(5000);
        inputField.GetComponent<InputField>().text = 90.ToString();
    }*/

    async Task onPointerDownEvent()
    {
        shouldStop = false;
        int parsed;
        while (!shouldStop)
        {
            parsed = int.Parse(inputField.GetComponent<InputField>().text);
            if (parsed < maximum)
            {
                parsed++;
            }
            inputField.GetComponent<InputField>().text = parsed.ToString();
            await Task.Delay(100);
        }
    }

    void onPointerUpEvent()
    {
        shouldStop = true;
    }
}
