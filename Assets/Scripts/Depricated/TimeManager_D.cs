using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager_D : MonoBehaviour {

    public Text timerText;
    public Text dayText;
    public Text dayStateText;
    private float startTime;
    private bool nightFlag;

    public float daysInMinutes;
    public int dayDuration;

    int noOfWorkers;
    bool called;
    float m;

    private string[] days = { "SATURDAY", "SUNDAY", "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY" };
    private string[] dayState = {"DAY", "NIGHT"};
    private int currentDay = 1;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        dayText.text = days[1];
        dayStateText.text = dayState[0];
        // h = (int)dayToHoursMinute;
        m = daysInMinutes; // so if there was a change in the inspector it won't affect the code
        nightFlag = false;
        dayDuration = (int)(m * 0.84);
        called = false;
        Debug.Log(GetTime(2) + " Second"); //In sec
        Debug.Log(GetTime(2)/60 + " Minute"); //In min
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        int hour = (int)((t / 3600) % 24);
        string hours = (hour).ToString();
        int minute = (int)((t / 60) % 60);
        string minutes = minute.ToString();
        float second = (t % 60);
        string seconds = second.ToString("f2");

        timerText.text = hours + " : " + minutes + " : " + seconds;

        double netSecond = (hour * 60 * 60) + (minute * 60) + second;

        double dayInSecond = m * 60;

        if ((int)netSecond == (int)dayInSecond)
        {
            startTime = Time.time;
            NextDay();
            called = false;

        }


        else if (netSecond >= (dayDuration*60))
        {
            dayStateText.text = dayState[1];
            nightFlag = true;
        }

        else if (netSecond < (dayDuration * 60))
        {
            if (!called)
            {
                noOfWorkers = GenerateWorkers();
                called = true;
                Debug.Log(noOfWorkers);
            }

            dayStateText.text = dayState[0];
            nightFlag = false;
        }
            

    }

    public double GetTime(float d)
    {
        // return ((m * d * 1.0) / 60.0);
        return (m * d); //Scaling duration in sec
    }

    public void NextDay()
    {
        currentDay++;

        if (currentDay > 6) currentDay = 0;
        dayText.text = days[currentDay];


    }

    public int GenerateWorkers()
    {
        //Random rnd = new Random();
        System.Random rnd = new System.Random();
        int no = rnd.Next(0, 4);
        return no;
    }

}
