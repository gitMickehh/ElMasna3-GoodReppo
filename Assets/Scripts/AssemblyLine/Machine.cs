using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum MachineState
{
    Idle, Working, Broken
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

    [Header("Assembly Line")]
    public AssemblyLine assemblyLine;

    GlowObject glowObject;

    private void Awake()
    {
        assemblyLine = GetComponentInParent<AssemblyLine>();
        machineAnimator = GetComponentsInChildren<Animator>()[0];
        glowObject = GetComponent<GlowObject>();
    }


    private void Start()
    {
        SetMachineState(MachineState.Idle);

    }
    public void StopCountDown()
    {
        time = machineBase.DurationInMinutes * 60;
        StopCoroutine("StartCountDown");

    }

    public void CountDown()
    {
        StartCoroutine("StartCountDown");
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

            case MachineState.Broken:
                machineAnimator.SetBool("Working", false);
                /*
                if (worker)
                {
                    worker.SetWorkerState(WorkerState.Idle);
                }
                */
                break;
        }
    }

    public void MachineBrokenDown()
    {
        SetMachineState(MachineState.Broken);
        glowObject.GlowMachine();

        //assemblyLine.isWorking = false;
    }

    public void StopMachine()
    {
        StopCountDown();
        SetMachineState(MachineState.Idle);
        if (worker)
            worker.SetWorkerState(WorkerState.Idle);
    }

}
