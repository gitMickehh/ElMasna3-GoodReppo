using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum MachineState
{
    Idle, Working
}
public class Machine : MonoBehaviour
{
    [Header("Machine")]
    public Machine_SO machineBase;
    public Animator machineAnimator;

    public Transform workerPosition;
    public MachineState machineState;

    [Header("Machine Time")]
    public Image fillImg;
    float time;

    [Header("Worker On Task")]
    public Worker worker;


    private void Awake()
    {
        machineAnimator = GetComponentsInChildren<Animator>()[0];
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

        if (time <= 0)
        {
            fillImg.fillAmount = 1;
            StopCountDown();
        }
    }

    private void Start()
    {
        //isWorking = true;
        //machineState = MachineState.Idle
        SetMachineState(MachineState.Idle);
    }
    public void StopCountDown()
    {
        time = machineBase.DurationInMinutes * 60;
        StopCoroutine(StartCountDown());

    }

    public void SetMachineState(MachineState state)
    {
        machineState = state;

        switch (state)
        {
            case MachineState.Idle:
                machineAnimator.SetBool("Working", false);
                break;

            case MachineState.Working:
                machineAnimator.SetBool("Working", true);

                break;
        }
    }

}
