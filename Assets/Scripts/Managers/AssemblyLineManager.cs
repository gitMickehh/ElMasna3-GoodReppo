using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLineManager : MonoBehaviour {

    public List<AssemblyLine> assemblyLines;
    public CompanyMoneyUpdates_SO companyMoneyUpdates_SO;
    public double moneyMadeInLines;

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
}
