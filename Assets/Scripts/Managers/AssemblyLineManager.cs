using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLineManager : MonoBehaviour
{

    public List<AssemblyLine> assemblyLines;
    public CompanyMoneyUpdates_SO companyMoneyUpdates_SO;
    public double moneyMadeInLines;
    public bool canAssign;

    private void Start()
    {
        canAssign = true;
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
        int i = 0;
        while (assemblyLines[i].workerFull && (i != assemblyLines.Count))
        {
            i++;
        }

        if (i == assemblyLines.Count)
        {
            // canAssign = false;
            print("Something not being handled.");


        }
        else
        {
            assemblyLines[i].AddNewWorkerToAssembly(worker);
            if ((i == (assemblyLines.Count - 1)) && assemblyLines[i].workerFull)
            {
                canAssign = false;
            }
        }

    }
}
