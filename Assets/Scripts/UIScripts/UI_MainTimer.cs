using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TimerType { Linear, Images, Radial, LinearAndImage}

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

    [Header("Linear and Image")]
    public Color DaySliderColor;
    public Color NightSliderColor;
    public Image SliderFillImage;

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
                case TimerType.LinearAndImage:
                    timerSlider.value = percentage;
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

    /// <summary>
    /// d for Day, n for Night, default for day
    /// </summary>
    /// <param name="c"></param>
    public void DayOrNight(char c = 'd')
    {
        if(timerType == TimerType.LinearAndImage)
        {
            switch (c)
            {
                case 'd':
                    timeImage.sprite = daySprite;
                    SliderFillImage.color = DaySliderColor;
                    break;
                case 'n':
                    timeImage.sprite = nightSprite;
                    SliderFillImage.color = NightSliderColor;
                    break;
                default:
                    break;
            }
        }
    }

}
