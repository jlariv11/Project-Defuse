using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 120;
    private Text timeText;
    private float timer;
    [SerializeField]
    private Image flash;
    private bool isTimeUp;
    private bool running;
    public UnityEvent timeUpEvent;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        timer = maxTime;
        timeText.text = formatTime();
        isTimeUp = false;
        running = true;
        if(timeUpEvent == null)
        {
            timeUpEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            return;
        }
        if (timer <= 0)
        {
            timeText.text = "0:00";
            flash.gameObject.SetActive(true);
            isTimeUp = true;
            timeUpEvent.Invoke();
            return;
        }
        timer -= Time.deltaTime;
        timeText.text = formatTime();
    }

    private string formatTime()
    { 
        int mins = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        return mins + ":" + (seconds < 10 ? ("0" + seconds) : seconds);
    }

    public bool timeUp()
    {
        return isTimeUp;
    }

    public void stop()
    {
        running = false;
    }

}
