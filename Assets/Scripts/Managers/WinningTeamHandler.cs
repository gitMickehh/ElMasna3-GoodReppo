using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTeamHandler : MonoBehaviour {

    public WorkerManager workerManager;

    public void RedTeamWin()
    {
        workerManager.LevelUpTeam(WorkerManager.TShirtsColor.Red);
        workerManager.ChangeTotalRedColor();
    }

    public void YellowTeamWin()
    {
        workerManager.LevelUpTeam(WorkerManager.TShirtsColor.Yellow);
        workerManager.ChangeTotalYellowColor();
    }

    public void GreenTeamWin()
    {
        workerManager.LevelUpTeam(WorkerManager.TShirtsColor.Green);
        workerManager.ChangeTotalGreenColor();
    }

    //public void BlueTeamWin()
    //{
    //    workerManager.LevelUpTeam(WorkerManager.TShirtsColor.Blue);
    //    workerManager.ChangeTotalBlueColor();
    //}

}
