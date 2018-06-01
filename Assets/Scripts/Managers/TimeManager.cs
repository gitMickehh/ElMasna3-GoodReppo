using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Day
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public class TimeManager : MonoBehaviour {

    [Header("Game Time")]
    public Day dayInGame = Day.Sunday;
    public float dayDurationMinutes = 60f;

    [Header("Events")]
    public GameEvent_SO startDayEvent;
    public GameEvent_SO endDayEvent;

    [Header("Game Dates")]
    public DateTime_SO firstTimePlayed;
    public DateTime_SO lastTimePlayed;

    [Header("Time UI")]
    public UI_MainTimer timer;

    [Header("Scriptable Objects")]
    public CompanyMoneyUpdates_SO companyMoneyUpdates_SO;
    public Factory_SO factory_SO;

    [Header("Manager")]
    public AssemblyLineManager assemblyLineManager;

    //properties
    public float MorningDuration
    {
        get
        {
            return (dayDurationMinutes * 0.84f);
        }
    }
    public float NightDuration
    {
        get
        {
            return dayDurationMinutes - MorningDuration;
        }
    }

    float timeLeft;
    float timeLeftSec;

    //Unity
    private void Start()
    {
        //here we call a function to calculate t in ContinueTimer(t)
        DateClass timeNow = DateTime_SO.GetTimeNow();
        GetSetDay();
        CalculateTimeGap(timeNow);

        timer.maxTimeSeconds = dayDurationMinutes * 60;
        timer.timeLeftSeconds = timeLeft * 60 + timeLeftSec;
    }

    private void OnApplicationQuit()
    {
        SaveDay();
    }

    //Calculate Time 
    void CalculateTimeGap(DateClass timeNow)
    {
        //first time difference
        float deltaMinuteFromFirst = lastTimePlayed.date.Minute - firstTimePlayed.date.Minute;
        if (deltaMinuteFromFirst < 0)
        {
            deltaMinuteFromFirst += (int)dayDurationMinutes;
        }

        float deltaSecondFromFirst = lastTimePlayed.date.Second - firstTimePlayed.date.Second;
        if (deltaSecondFromFirst < 0)
        {
            deltaSecondFromFirst += 60;
        }
        
        //minutes
        float minuteDifference = timeNow.Minute - lastTimePlayed.date.Minute + deltaMinuteFromFirst;
        if (minuteDifference < 0)
        {
            minuteDifference += (int)dayDurationMinutes;
        }
        else if (minuteDifference >= (int)dayDurationMinutes)
        {

        }

        //seconds
        float secondDifference = timeNow.Second - lastTimePlayed.date.Second + deltaSecondFromFirst;
        if (secondDifference < 0)
        {
            secondDifference += 60;
        }
        else if (secondDifference >= 60)
        {

        }

        timeLeft = dayDurationMinutes - minuteDifference;
        timeLeftSec = secondDifference % 60;

        //TimeLog.MyLog("Difference from last log in: " + minuteDifference + ":" + secondDifference);
        TimeLog.MyLog("Time left for one hour: " + timeLeft + ":" + timeLeftSec);

        if (timeLeft <= NightDuration)
        {
            //night
            StartCoroutine(ContinueTimerNight(timeLeft*60 + timeLeftSec));
        }
        else
        {
            //morning
            StartCoroutine(ContinueTimer(timeLeft * 60 + timeLeftSec));
        }

        //for score calculation (WAS A FUNCTION) but i merged them into one because of redundant minute and second difference

        //hours
        int hourDifference = timeNow.Hour - lastTimePlayed.date.Hour;
        if (hourDifference < 0)
        {
            hourDifference += 24;
        }

        //days
        int dayDifference = timeNow.Day - lastTimePlayed.date.Day;
        if (dayDifference < 0)
        {
            dayDifference += 30;
        }

        //Months and years
        int yearsDifference = timeNow.Year - lastTimePlayed.date.Year;
        int monthsDifference = timeNow.Month - lastTimePlayed.date.Month;
        if (monthsDifference < 0)
        {
            monthsDifference += 12;
        }

        AddDay(yearsDifference, monthsDifference, dayDifference, hourDifference);
        CalculateScore(yearsDifference, monthsDifference, dayDifference, hourDifference, minuteDifference, secondDifference);
    }

    //Calculate Score
    void CalculateScore(int dYear, int dMonth, int dDays, int dHours, float dMinutes, float dSeconds)
    {
        //calculate score here
        Debug.Log("Years: " + dYear + ", Months: " + dMonth + ", Days: " + dDays + ", Hours: " + dHours + ", Minutes: "+ dMinutes + ", Seconds: "+ dSeconds+ "\n");
        Debug.Log("Time Missed: " + dMinutes + ":" + dSeconds);
        float timeInMin = (dYear * (518400)) + (dMonth * (43200)) + (dDays * (1440)) + (dHours * (60)) + dMinutes + (dSeconds / (60.0f));

        //add money to factory_so
        assemblyLineManager.CalcAssemblyLinesProfit();
        factory_SO.DepositMoney(companyMoneyUpdates_SO.assemblyLinesProfit * timeInMin);

    }

    //Setting Day
    void AddDay()
    {
        dayInGame++;

        if ((int)dayInGame > 6)
            dayInGame = 0;
    }

    void AddDay(int nOfYears, int nOfMonths, int nOfDays,int nOfHours)
    {
        int totalHours = ConvertToHours(nOfYears,nOfMonths,nOfDays,nOfHours);
        AddDay(totalHours);
    }

    void AddDay(int nOfHours)
    {
        int total = nOfHours + (int)dayInGame;
        dayInGame = (Day)(total % 7);
    }

    //Hour Conversion
    int ConvertToHours(int nOfYears, int nOfMonths, int nOfDays, int nOfHours)
    {
        int totalHours = 0;
        //transform all to hours:
        if (nOfYears == 0)
        {
            if (nOfMonths == 0)
            {
                if (nOfDays == 0)
                {
                    totalHours = nOfHours;
                }
                else
                {
                    totalHours = nOfHours + (nOfDays * 24);
                }
            }
            else
            {
                totalHours = nOfHours + (nOfMonths * 730);
            }
        }
        else
        {
            totalHours = nOfHours + (nOfYears * 8760);
        }

        return totalHours;
    }

    //Player Prefs
    void SaveDay()
    {
        PlayerPrefs.SetInt("Day", (int)dayInGame);
    }

    void GetSetDay()
    {
        var dayN = PlayerPrefs.GetInt("Day");
        dayInGame = (Day)dayN;
    }

    //Coroutines
    IEnumerator ActivateTimer()
    {
        while(true)
        {
            startDayEvent.Raise();
            Debug.Log("Morning, " + dayInGame.ToString() + ", day: " + MorningDuration * 60 + " seconds");
            yield return new WaitForSeconds(MorningDuration * 60);

            endDayEvent.Raise();
            Debug.Log("Night" + ", day: " + (NightDuration) * 60 + " seconds");
            yield return new WaitForSeconds(NightDuration * 60);

            AddDay();
        }
    }

    IEnumerator ContinueTimer(float t)
    {
        //called if t (minutes) < MorningDuration
        //t is in seconds
        Debug.Log("Morning");
        yield return new WaitForSeconds(t);

        Debug.Log("Night");
        yield return new WaitForSeconds(NightDuration * 60);

        AddDay();
        StartCoroutine(ActivateTimer());
    }

    IEnumerator ContinueTimerNight(float t)
    {
        //called if t (minutes) > MorningDuration
        //t is in seconds
        TimeLog.MyLog("Night duration: " + t);

        yield return new WaitForSeconds(t);

        Debug.Log("Day Ended");
        AddDay();
        StartCoroutine(ActivateTimer());
    }
}
