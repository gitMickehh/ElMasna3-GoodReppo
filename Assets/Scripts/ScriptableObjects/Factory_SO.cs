using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Factory", menuName = "ElMasna3/Factory/Factory")]
public class Factory_SO : ScriptableObject
{

    public string PlayerName;
    //public Day factoryDay = Day.Sunday;

    [Header("Dates")]
    public DateTime_SO FirstLoginTime;
    public DateTime_SO LastTimeLogin;

    [Header("Factory Money")]
    public double FactoryMoney = 2000;
    public int companyLevel;

    [Header("Events")]
    public GameEvent_SO factoryMoneyChanged;
    public GameEvent_SO factory_LevelUpEvent;

    public CompanyMoneyUpdates_SO companyMoney;

    public void LevelUp()
    {
        WithdrawMoney(companyMoney.LevelUpCost);
        companyLevel++;
        factory_LevelUpEvent.Raise();
    }

    public void TeamLevelUp(int index)
    {
        switch (index)
        {
            case 0:
                WithdrawMoney(companyMoney.playForRedTeam);
                break;

            case 1:
                WithdrawMoney(companyMoney.playForYellowTeam);
                break;

            case 2:
                WithdrawMoney(companyMoney.playForGreenTeam);
                break;

                //case 3:
                //    WithdrawMoney(companyMoney.playForBlueTeam);
                //    break;
        }
    }


    public void WithdrawMoney(float money)
    {
        if (money <= FactoryMoney)
        {
            FactoryMoney -= money;
            factoryMoneyChanged.Raise();
        }
        else
            Debug.Log("Factory doesn't have enough money.");
    }

    public void DepositMoney(double money)
    {
        FactoryMoney += money;
        factoryMoneyChanged.Raise();
    }

    public bool CheckMoneyAvailability(float money)
    {
        if (FactoryMoney >= money)
            return true;

        return false;
    }
}