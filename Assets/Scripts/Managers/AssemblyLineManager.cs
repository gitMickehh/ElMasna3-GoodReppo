using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLineManager : MonoBehaviour
{

    public List<AssemblyLine> assemblyLines;
    public CompanyMoneyUpdates_SO companyMoneyUpdates_SO;
    public GameEvent_SO NewWorkerAdded;
    public double moneyMadeInLines;
    public bool canAssign;

    private void Start()
    {
        if (CheckForAssigningWorker() != null)
            canAssign = true;
        else
            canAssign = false;

        print("index of assembly available: " + CheckForAssigningWorker());
    }

    public void CalcAssemblyLinesProfit()
    {
        companyMoneyUpdates_SO.assemblyLinesProfit = 0;
        moneyMadeInLines = 0;

        for (int i = 0; i < assemblyLines.Count; i++)
        {
            if (assemblyLines[i].isWorking)
            {
                moneyMadeInLines += assemblyLines[i].CalcMoneyMadePerMin();
            }

        }
        companyMoneyUpdates_SO.assemblyLinesProfit = moneyMadeInLines;

    }

    public void AddNewWorkerToAssemb(Worker worker)
    {
        int? index = CheckForAssigningWorker();

        if (index != null)
        {
            //assemblyLines[(int)index].AddNewWorkerToAssembly(worker);
            assemblyLines[(int)index].PendWorker(worker);
            if ((index == (assemblyLines.Count - 1)) && assemblyLines[(int)index].workerFull)
            {
                canAssign = false;
            }
            NewWorkerAdded.Raise();
        }

        else
            print("something wrong"); //the function shouldn't be called if there was no room available

    }

    public int? CheckForAssigningWorker() //returns index of assemblyLine which can be assigned
    {
        int i = 0;
        while ((i != assemblyLines.Count) && (assemblyLines[i].workerFull))
        {
            i++;
        }

        if (i == assemblyLines.Count)
        {
            // canAssign = false;
            print("Something not being handled.");
            return null;
        }
        else
            return i;
    }


}
