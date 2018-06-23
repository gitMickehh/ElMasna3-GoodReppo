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

    public Factory_SO factory_SO;
    public GameEvent_SO machineFixed;
    public GameEvent_SO machineIssue;

    GlowObject glowObject;

    public float FixingCost
    {
        get
        {
            return 500 * Mathf.Pow(1.3f, factory_SO.companyLevel);
        }
    }

    private void Awake()
    {
        assemblyLine = GetComponentInParent<AssemblyLine>();
        if (GetComponentsInChildren<Animator>().Length > 0)
            machineAnimator = GetComponentsInChildren<Animator>()[0];
        else
            machineAnimator = null;
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
                if (machineAnimator)
                    machineAnimator.SetBool("Working", false);
                break;

            case MachineState.Working:
                if (machineAnimator)
                    machineAnimator.SetBool("Working", true);
                break;

            case MachineState.Broken:
                if (machineAnimator)
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
        //FindObjectOfType<ComplaintsManager>().AddFixMachineComp();
        machineIssue.Raise();
        SetMachineState(MachineState.Broken);
        glowObject.GlowMachine();
        GetComponent<ClickableMachine>().enabled = true;

        //assemblyLine.isWorking = false;
    }

    public void StopMachine()
    {
        StopCountDown();
        SetMachineState(MachineState.Idle);
        if (worker)
            worker.SetWorkerState(WorkerState.Idle);
    }

    public void MachineFixed()
    {
        //SetNormal();
        //FindObjectOfType<ComplaintsManager>().FixMachine();
        glowObject.StopGlowing();
        GetComponent<ClickableMachine>().enabled = false;
        print(transform.name + " got fixed");
        assemblyLine.ReturnToWork();
        machineFixed.Raise();

    }

    //public void SetNormal()
    //{
    //    if (worker)
    //    {
    //        SetMachineState(MachineState.Working);
    //        //worker.SetWorkerState(WorkerState.Working);
    //    }
    //    else
    //    {
    //        SetMachineState(MachineState.Idle);
    //    }
    //}



}
