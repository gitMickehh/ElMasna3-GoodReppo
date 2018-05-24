using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainTimer : MonoBehaviour {


    public float maxTimeSeconds = 60;
    public float timeLeftSeconds = 60;

    float percentage;

    public Slider timerSlider;

	void Update () {


        if(timeLeftSeconds >= 0)
        {
            timeLeftSeconds -= Time.deltaTime;

            percentage = timeLeftSeconds / maxTimeSeconds;
            timerSlider.value = percentage;
        }
        else
        {
            timeLeftSeconds = maxTimeSeconds;
        }
    }



}
