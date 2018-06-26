using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public Image fillImg;
    float timeAmt = 30;
    float time;
    bool timeIsUp;

    public void StartTimer()
    {
       fillImg = GetComponentInChildren<Image>();
        time = timeAmt;
        timeIsUp = false;
        StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        while (time > 0 && !timeIsUp)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            fillImg.fillAmount = time / timeAmt;
        }
    }

    public void StopCountDown()
    {
        //print("here");
        timeIsUp = true;
        StopCoroutine("CountDown");
    }
}
