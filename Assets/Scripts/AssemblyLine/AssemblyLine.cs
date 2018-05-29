using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLine: MonoBehaviour
{

    [Header("Machines")]
    public Machine_SO machineBase;
    public List<Machine> Machines;

    [Header("Workers")]
    public List<Worker> workersInLine;

    [Header("Factory")]
    public Factory_SO Factory_SO;

    [Header("Event")]
    public GameEvent_SO L_IterationFinished;

    float moneyMadeInLine;
    int j;

    private void Start()
    {
        j = 0;
        moneyMadeInLine = 0;

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

                j++;
                moneyMadeInLine += (50 * Mathf.Pow((1.2f), workersInLine[i].level)) + ((Factory_SO.companyLevel - 1) * 100);
            }

            yield return new WaitForSeconds(machineBase.DurationInMinutes*60); // *60

            if (j >= Machines.Count)
            {
                L_IterationFinished.Raise();
                j = 0;
            }
        }
    }

    public void DepositMoneyToFactory()
    {
        print("L_IterationFinished has been raised.");
        Factory_SO.DepositMoney(moneyMadeInLine);
        moneyMadeInLine = 0;
    }
}
