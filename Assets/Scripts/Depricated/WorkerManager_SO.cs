using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Worker Manager Holder", menuName = "ElMasna3/Factory/Worker Manager")]
public class WorkerManager_SO : ScriptableObject {

    public WorkerManagerList_SO redWorkers;
    public WorkerManagerList_SO greenWorkers;
    public WorkerManagerList_SO yellowWorkers;
    public WorkerManagerList_SO blueWorkers;

    public void AddRed(Worker w)
    {
        redWorkers.Add(w);
    }

    public void AddGreen(Worker w)
    {
        greenWorkers.Add(w);
    }

    public void AddYellow(Worker w)
    {
        yellowWorkers.Add(w);
    }

    public void AddBlue(Worker w)
    {
        blueWorkers.Add(w);
    }


}
