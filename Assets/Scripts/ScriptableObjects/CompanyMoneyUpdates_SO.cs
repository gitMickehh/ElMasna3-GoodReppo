using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyMoneyUpdates", menuName = "ElMasna3/Factory/CompanyMoneyUpdates")]
public class CompanyMoneyUpdates_SO : ScriptableObject
{

    public float levelUpCost = 20000;

    public float playForRedTeam;
    public float playForYellowTeam = 300;
    public float playForGreenTeam;
    //public float playForBlueTeam;

    public Factory_SO Factory_SO;
    public WorkerManager WorkerManager;

    public float LevelUpCost
    {
        get
        {
            //Debug.Log("CompanyMoneyUpdates_SO");
            levelUpCost = Factory_SO.companyLevel * 20000;
            return levelUpCost;

        }
    }

    ////public float PlayForRedTeam
    ////{
    ////    get
    ////    {
    ////        Debug.Log("TotalRedColor: " + WorkerManager.TotalRedColor);
    ////        if (WorkerManager.RedColorOverSix > 0)
    ////            playForRedTeam = 500 * (WorkerManager.TotalRedColor) / (WorkerManager.RedColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    ////        return playForRedTeam;
    ////    }
    ////}

    ////public float PlayForYellowTeam
    ////{
    ////    get
    ////    {
    ////        Debug.Log("TotalYellowColor: " + WorkerManager.TotalYellowColor);
    ////        if (WorkerManager.TotalYellowColor > 0)
    ////            playForYellowTeam = 500 * (WorkerManager.TotalYellowColor) / (WorkerManager.YellowColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    ////        return playForYellowTeam;
    ////    }
    ////}

    ////public float PlayForGreenTeam
    ////{
    ////    get
    ////    {
    ////        Debug.Log("TotalGreenColor: " + WorkerManager.TotalGreenColor);
    ////        if (WorkerManager.GreenColorOverSix > 0)
    ////            playForGreenTeam = 500 * (WorkerManager.TotalGreenColor) / (WorkerManager.GreenColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    ////        return playForGreenTeam;
    ////    }
    ////}

    //public float PlayForBlueTeam
    //{
    //    get
    //    {
    //        if (WorkerManager.BlueColorOverSix > 0)
    //            playForBlueTeam = 500 * (WorkerManager.TotalBlueColor) / (WorkerManager.BlueColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    //        return playForBlueTeam;
    //    }
    //}

    //public void updatePlayingForTeam()
    //{
    //    int shirtsColor = PlayToRaiseTeamLevel.index;
    //    switch (shirtsColor)
    //    {
    //        case 0:
    //            Debug.Log("TotalRedColor: " + WorkerManager.TotalRedColor);
    //            if (WorkerManager.RedColorOverSix > 0)
    //                playForRedTeam = 500 * (WorkerManager.TotalRedColor) / (WorkerManager.RedColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    //            break;

    //        case 1:
    //            Debug.Log("TotalYellowColor: " + WorkerManager.TotalYellowColor);
    //            if (WorkerManager.TotalYellowColor > 0)
    //                playForYellowTeam = 500 * (WorkerManager.TotalYellowColor) / (WorkerManager.YellowColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    //            break;

    //        case 2:
    //            Debug.Log("TotalGreenColor: " + WorkerManager.TotalGreenColor);
    //            if (WorkerManager.GreenColorOverSix > 0)
    //                playForGreenTeam = 500 * (WorkerManager.TotalGreenColor) / (WorkerManager.GreenColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    //            break;

    //            //case WorkerManager.TShirtsColor.Blue:
    //            //if(WorkerManager.BlueColorOverSix > 0)
    //            //playForBlueTeam = 500 * (WorkerManager.TotalBlueColor) / (WorkerManager.BlueColorOverSix) + ((Factory_SO.companyLevel - 1) * 100);
    //            //    break;
    //    }
    //}

    
}
