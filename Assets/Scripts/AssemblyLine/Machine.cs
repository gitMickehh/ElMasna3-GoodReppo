using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Machine : MonoBehaviour {

    [Header("Machine")]
    public Machine_SO machineBase;
    //[SerializeField]
    //public static float DurationInMinutes = 2f;
    public Transform workerPosition;
    public Image fillImg;
    float time;

    [Header("Worker On Task")]
    public Worker worker;
    
    public float OverallTimeSeconds
    {
        get
        {
            return (machineBase.DurationInMinutes * 60) / worker.workingSpeed;
        }
    }

    public IEnumerator ActivateMachine()
    {
        yield return new WaitForSeconds(OverallTimeSeconds);

    }

    public IEnumerator StartCountDown()
    {
        time = machineBase.DurationInMinutes * 60;
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time -= 1;
            fillImg.fillAmount = time / (machineBase.DurationInMinutes * 60);
        }

        if(time <= 0)
        {
            StopCountDown();
        }
    }

    public void StopCountDown()
    {
        StopCoroutine(StartCountDown());
        time = machineBase.DurationInMinutes * 60;
    }

}
