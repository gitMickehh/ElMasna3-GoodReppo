using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

//public enum Day { SUNDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY };

public class TimeEvent : MonoBehaviour
{


    public Text timerText;
    public Text DayText;

    private float startTime;

    public delegate void DayAction();
    public static event DayAction OnNewDay;

    public delegate void NightAction();
    public static event NightAction OnNightTime;

    public float dayInMin;
    public int dayDurationInMin;
    public Day currentDay;

    public GameEvent_SO StartDayEvent;
    public GameEvent_SO EndDayEvent;

    void Start()
    {

        dayDurationInMin = (int)(0.84 * dayInMin);
        currentDay = 0;
        StartCoroutine("MyEvent");

    }

    void Update()
    {
        WriteTimeInBox();
    }

    private IEnumerator MyEvent()
    {

        while (true)
        {
            //raise NewDayEvent
            if (OnNewDay != null)
            {
                NextDay();
                OnNewDay();
            }

            //Night event
            yield return new WaitForSeconds(dayDurationInMin * 60);
            if (OnNightTime != null)
            {
                Debug.Log("Night Time");
                EndDayEvent.Raise();
                OnNightTime();
            }

            yield return new WaitForSeconds((dayInMin - dayDurationInMin) * 60);
        }
    }

    public void NextDay()
    {
        Debug.Log("New Day rises");
        startTime = Time.time;
        DayText.text = currentDay.ToString();

        print(currentDay);

        currentDay++;

        if ((int)currentDay > 6)
            currentDay = 0;

        StartDayEvent.Raise();
    }

    public void WriteTimeInBox()
    {
        float t = Time.time - startTime;
        int hour = (int)((t / 3600) % 24);
        string hours = (hour).ToString();
        int minute = (int)((t / 60) % 60);
        string minutes = minute.ToString();
        float second = (t % 60);
        string seconds = second.ToString("f2");

        timerText.text = hours + " : " + minutes + " : " + seconds;
        //timerText.text = "ماهر";  //WORKS
    }
}
