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
    public List<Worker> pendingWorkers;

    [Header("Factory")]
    public Factory_SO Factory_SO;

    [Header("Event")]
    public GameEvent_SO L_IterationFinished;

    [Header("Assembly Line")]
    public bool isWorking;
    public bool workerFull;

    [Header("Worker Manager")]
    public WorkerManager workerManager;

    public float moneyMadeInLine;
    int j;

    private void Start()
    {
        j = 0;
        moneyMadeInLine = 0;
        isWorking = true;
        workerFull = CheckForWorkersCount();

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
                if (workersInLine[i].machineAssigned)
                {
                    workersInLine[i].machineAssigned.SetMachineState(MachineState.Idle);
                    workersInLine[i].machineAssigned.worker = null;
                    workersInLine[i].machineAssigned = null;
                }

                workersInLine[i].AssignWorker(Machines[j]);

                moneyMadeInLine += (50 * Mathf.Pow((1.2f), workersInLine[i].level)) + ((Factory_SO.companyLevel - 1) * 100);
                j++;

            }
            StartCountDown();
            yield return new WaitForSeconds(machineBase.DurationInMinutes * 60);

            if (j >= Machines.Count)
            {
                //Iteration Finished

                DepositMoneyToFactory();

                AddPendingWorkersToLine();
                moneyMadeInLine = 0;

                j = 0;
            }

        }
    }

    public void StartCountDown()
    {
        for (int i = 0; i < Machines.Count; i++)
            if (Machines[i].worker)
                //StartCoroutine("Machines[i].StartCountDown");
                Machines[i].CountDown();

    }


    public void DepositMoneyToFactory()
    {
        //if(!isWorking)
        //    moneyMadeInLine = 0;
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

    public bool CheckForWorkersCount()
    {
        if ((workersInLine.Count + pendingWorkers.Count) == Machines.Count)
        {
            workerFull = true;
        }
        else
            workerFull = false;

        return workerFull;
    }

    public void PendWorker(Worker worker)
    {
        pendingWorkers.Add(worker);
        CheckForWorkersCount();
    }

    public void AddPendingWorkersToLine()
    {
        for (int i = 0; i < pendingWorkers.Count; i++)
        {
            pendingWorkers[i].gameObject.SetActive(true);
            workersInLine.Add(pendingWorkers[i]);
            workerManager.WorkersPrefabs.Add(pendingWorkers[i].gameObject);
            workerManager.workersInOrientation.Remove(pendingWorkers[i].gameObject);
        }

        pendingWorkers.Clear();
    }

    public Machine RandomMachine()
    {
        int no = Random.Range(0, Machines.Count);
        return Machines[no];
    }

    public void StopLine()
    {
        StopCoroutine("AssignWorkersToMachinesAvailable");
        isWorking = false;
        for(int i = 0; i< Machines.Count; i++)
        {
            Machines[i].StopMachine();
        }

        moneyMadeInLine = 0; //not sure!!
        j = 0;
    }

    public void ReturnToWork()
    {
        isWorking = true;
        StartCoroutine("AssignWorkersToMachinesAvailable");
        
    }

}
