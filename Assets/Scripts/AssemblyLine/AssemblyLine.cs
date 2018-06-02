using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLine : MonoBehaviour
{
    [SerializeField]
    AssemblyLineManager assemblyLineManager;

    [Header("Machines")]
    public Machine_SO machineBase;
    public List<Machine> Machines;

    [Header("Workers")]
    public List<Worker> workersInLine;

    [Header("Factory")]
    public Factory_SO Factory_SO;

    [Header("Event")]
    public GameEvent_SO L_IterationFinished;

    [Header("Assembly Line")]
    public bool isWorking;

    float moneyMadeInLine;
    int j;

    private void Start()
    {
        j = 0;
        moneyMadeInLine = 0;
        isWorking = true;
        //print("set isworking to true");

        assemblyLineManager = FindObjectOfType<AssemblyLineManager>();
        assemblyLineManager.assemblyLines.Add(gameObject.GetComponent<AssemblyLine>());

        if (workersInLine[0] != null)
        {
            StartCoroutine("AssignWorkersToMachinesAvailable");
        }

    }

    public IEnumerator AssignWorkersToMachinesAvailable()
    {
        while (true)
        {

            for (int i = 0; i < workersInLine.Count && j < Machines.Count; i++)
            {
                workersInLine[i].AssignWorker(Machines[j].workerPosition);
                //workersInLine[i].SetWorkerState(WorkerState.Working);
                StartCoroutine(Machines[j].StartCountDown());

                j++;
                moneyMadeInLine += (50 * Mathf.Pow((1.2f), workersInLine[i].level)) + ((Factory_SO.companyLevel - 1) * 100);
            }
           // workersInLine[0].PlayerWon();
            SetWorkersInLineWorking();
            yield return new WaitForSeconds(machineBase.DurationInMinutes * 60); // *60

           // SetWorkersInLineIdle();

            if (j >= Machines.Count)
            {
                //Iteration Finished

                L_IterationFinished.Raise();
                moneyMadeInLine = 0;

                j = 0;
            }
           
        }
    }

    public void SetWorkersInLineWorking()
    {
       for (int i = 0; i < workersInLine.Count; i++)
       {
            workersInLine[i].SetWorkerState(WorkerState.Working);
       }
    }
/*
    public void SetWorkersInLineIdle()
    {
        for (int i = 0; i < workersInLine.Count; i++)
        {
            workersInLine[i].SetWorkerState(WorkerState.Idle);
        }
    }
*/
    public void DepositMoneyToFactory()
    {
        print("L_IterationFinished has been raised.");
        Factory_SO.DepositMoney(moneyMadeInLine);
        moneyMadeInLine = 0;
    }


    public float CalcMoneyMadePerMin()
    {
        float moneyPerAssem = 0;
        float moneyPerMin = 0;

        for (int i = 0; i < workersInLine.Count; i++)
        {
            moneyPerAssem += (50 * Mathf.Pow((1.2f), workersInLine[i].level)) + ((Factory_SO.companyLevel - 1) * 100);
        }

        switch (workersInLine.Count)
        {
            case 1:
                moneyPerMin = moneyPerAssem / 10.0f;
                break;

            case 2:
                moneyPerMin = moneyPerAssem / 6.0f;
                break;

            case 3:
                moneyPerMin = moneyPerAssem / 4.0f;
                break;

            case 4:
                moneyPerMin = moneyPerAssem / 4.0f;
                break;

            case 5:
                moneyPerMin = moneyPerAssem / 2.0f;
                break;

            default:
                break;
        }

        return moneyPerMin;
    }


}
