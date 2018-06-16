using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TimerType { Linear, Images, Radial}

public class UI_MainTimer : MonoBehaviour {


    public TimerType timerType;
    public float maxTimeSeconds = 60;
    public float timeLeftSeconds = 60;

    float percentage;

    [Header("Linear Timer")]
    public Slider timerSlider;

    [Header("Images Timer")]
    public Sprite daySprite;
    public Sprite nightSprite;
    public Image timeImage;

    void Update () {

        if(timeLeftSeconds >= 0)
        {
            timeLeftSeconds -= Time.deltaTime;

            percentage = timeLeftSeconds / maxTimeSeconds;

            switch (timerType)
            {
                case TimerType.Linear:
                    timerSlider.value = percentage;
                    break;
                case TimerType.Images:
                    if(1-percentage <= 0.84f)
                    {
                        timeImage.sprite = daySprite;
                    }
                    else
                    {
                        timeImage.sprite = nightSprite;
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            timeLeftSeconds = maxTimeSeconds;
        }
    }




}
