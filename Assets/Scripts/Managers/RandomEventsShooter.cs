using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventsShooter : MonoBehaviour {

    public float MaximumMinutesBetweenEvents = 10;
    float previousTimeWaited = 0;

    [Header("Events")]
    public RandomEventsList_SO randomEventsList;
    public GameEvent_SO eventPicked;

    void Start() {

        StartCoroutine(RandomEvents());
    }

    IEnumerator RandomEvents()
    {
        while (true)
        {
            float waitTime = GetRandomTime();

            yield return new WaitForSeconds(waitTime);

            eventPicked = randomEventsList.PickRandomEvent();
            if (eventPicked)
                eventPicked.Raise();

            previousTimeWaited = waitTime;
        }
    }

    float GetRandomTime()
    {
        float n; 

        if (previousTimeWaited < 4 && previousTimeWaited != 0)
        {
            n = Random.Range(4f, MaximumMinutesBetweenEvents);
        }
        else
        {
            n = Random.Range(1f, MaximumMinutesBetweenEvents);
        }

        return n;
    }

    public void ResetGenerator()
    {
        StopCoroutine(RandomEvents());
        previousTimeWaited = 0;
    }
}
