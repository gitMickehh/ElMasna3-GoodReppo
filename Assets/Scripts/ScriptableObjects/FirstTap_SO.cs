using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstTap_SO", menuName = "ElMasna3/FirstTap_SO")]
public class FirstTap_SO : ScriptableObject
{

    public float firstTapTime = 0;
    public float doubleTapTimeDiff = 0.25f;

    public GameEvent_SO doubleTapEvent;

    public float TimeSinceLastTap()
    {
        float currentTime = Time.time;
        return (currentTime - firstTapTime);
    }

    public void CheckForDoubleTap()
    {
        if ((TimeSinceLastTap() < doubleTapTimeDiff) && (TimeSinceLastTap() != 0))
        {
            doubleTapEvent.Raise();
            firstTapTime = 0;
        }

        else
        {
            firstTapTime = Time.time;
            Debug.Log("TimeSinceLastTap: " + TimeSinceLastTap());
        }
    }
}
