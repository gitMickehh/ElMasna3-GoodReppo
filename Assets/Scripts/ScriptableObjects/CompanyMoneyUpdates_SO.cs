using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyMoneyUpdates", menuName = "ElMasna3/Factory/CompanyMoneyUpdates")]
public class CompanyMoneyUpdates_SO : ScriptableObject {

    public float levelUpCost= 20000;

    public float playForRedTeam;
    public float playForYellowTeam;
    public float playForPurpleTeam;

    public Factory_SO Factory_SO;

    public void UpdateLevelUpCost()
    {
        Debug.Log("CompanyMoneyUpdates_SO");
        levelUpCost = Factory_SO.companyLevel * 20000;
    }
}
