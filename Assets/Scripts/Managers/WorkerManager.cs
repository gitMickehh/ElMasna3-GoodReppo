using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WorkerManager : MonoBehaviour
{
    public enum TShirtsColor { Red, Green, Yellow, Blue };

    [Header("Worker Manager Lists")]
    public List<GameObject> WorkersPrefabs;
    public List<GameObject> workersInOrientation;

    public List<Worker> RedWorkers;
    public List<Worker> GreenWorkers;
    public List<Worker> YellowWorkers;
    public List<Worker> BlueWorkers;

    [Header("Save Keys")]
    public ListOfStrings_SO listOfWorkerKeys;
    public WorkerSpawner workerSpawner;

    [Header("Scriptable Objects")]
    public CompanyMoneyUpdates_SO companyMoneyUpdates_SO;
    public Factory_SO factory_SO;

    [Header("Worker In MiniGame")]
    public Worker workerInGame;

    [Header("Manager")]
    public AssemblyLineManager assemblyLineManager;

    //properties
    public int TotalRedColor
    {
        get
        {
            if (RedWorkers != null)
                return RedWorkers.Count;
            else
                return 0;
        }
    }

    public int TotalGreenColor
    {
        get
        {
            if (GreenWorkers != null)
                return GreenWorkers.Count;
            else
                return 0;
        }
    }

    public int TotalYellowColor
    {
        get
        {
            if (YellowWorkers != null)
                return YellowWorkers.Count;
            else
                return 0;
        }
    }

    public int TotalBlueColor
    {
        get
        {
            if (BlueWorkers != null)
                return BlueWorkers.Count;
            else
                return 0;
        }
    }

    public int RedColorOverSix
    {
        get
        {
            int count = 0;

            if(RedWorkers != null)
            {
                foreach (var worker in RedWorkers)
                {
                    if (worker.level >= 6)
                        count++;
                }
            }

            return count;
        }
    }

    public int GreenColorOverSix
    {
        get
        {
            int count = 0;

            if(GreenWorkers != null)
            {
                foreach (var worker in GreenWorkers)
                {
                    if (worker.level >= 6)
                        count++;
                }
            }

            return count;
        }
    }

    public int YellowColorOverSix
    {
        get
        {
            int count = 0;

            if (YellowWorkers != null)
            {
                foreach (var worker in YellowWorkers)
                {
                    if (worker.level >= 6)
                        count++;
                }
            }

            return count;
        }
    }

    public int BlueColorOverSix
    {
        get
        {
            int count = 0;

            if (BlueWorkers != null)
            {
                foreach (var worker in BlueWorkers)
                {
                    if (worker.level >= 6)
                        count++;
                }
            }

            return count;
        }
    }

    private void Start()
    {
        workerSpawner = GetComponent<WorkerSpawner>();

        LoadWorkers();
    }

    private void OnApplicationQuit()
    {
        SaveWorkersList(WorkersPrefabs);
    }

    //functions
    public Worker GetRandomWorker()
    {
        int no = Random.Range(0, WorkersPrefabs.Count);
        Worker worker = (WorkersPrefabs[no]).GetComponent(typeof(Worker)) as Worker;
        return worker;
    }

    public void DestroyWorkersInOrientation()
    {
        for(int i= workersInOrientation.Count-1; i>=0; i--)
        {
            var gOb = workersInOrientation[i].gameObject;
            Debug.Log("Destroying " + gOb.name);
            Destroy(gOb, 0.3f);
            RemoveFromColorList(gOb.GetComponent<Worker>());
            workersInOrientation.Remove(gOb);
        }

    }

    void RemoveFromColorList(Worker w)
    {
        switch (w.workerColor.colorName)
        {
            case "yellow":
                YellowWorkers.Remove(w);
                break;
            case "red":
                RedWorkers.Remove(w);
                break;
            case "blue":
                BlueWorkers.Remove(w);
                break;
            case "green":
                GreenWorkers.Remove(w);
                break;
            default:
                break;
        }
    }


    public void AddNewWorker(GameObject w)
    {
        //WorkersPrefabs.Add(w);
        workersInOrientation.Add(w);
    }
/*
    public void AddNewWorkerToFactory(GameObject w)
    {
        WorkersPrefabs.Add(w);
       // w.GetComponent<Worker>().AddToColorList();
    }
    */
    public void AddRedWorker(Worker w)
    {
        if(!RedWorkers.Contains(w))
            RedWorkers.Add(w);
    }

    public void AddGreenWorker(Worker w)
    {
        if(!GreenWorkers.Contains(w))
            GreenWorkers.Add(w);
    }

    public void AddYellowWorker(Worker w)
    {
        if(!YellowWorkers.Contains(w))
            YellowWorkers.Add(w);
    }

    public void AddBlueWorker(Worker w)
    {
        if(!BlueWorkers.Contains(w))
            BlueWorkers.Add(w);
    }

    
    //saving
    public void SaveWorkersList(List<GameObject> workersList)
    {
        listOfWorkerKeys.ClearList();

        for (int i = 0; i < workersList.Count; i++)
        {
            string key = "worker-" + (i + 1);
            Worker w = workersList[i].GetComponent<Worker>();
            w.SaveWorker(key);

        }

        string workerKeysJson = JsonUtility.ToJson(listOfWorkerKeys);
        PlayerPrefs.SetString("ListOfKeys",workerKeysJson);
    }

    void LoadKeyList()
    {
        if(PlayerPrefs.HasKey("ListOfKeys"))
        {
            //string workerKeysJson = PlayerPrefs.GetString("ListOfKeys");
            //Debug.Log(workerKeysJson);
            //listOfWorkerKeys.strings = JsonUtility.FromJson<ListOfStrings_SO>(workerKeysJson).strings;
        }
        else
        {
            Debug.Log("nothing saved");
        }
    }

    public void LoadWorkers()
    {
        LoadKeyList();

        for (int i = 0; i < listOfWorkerKeys.strings.Count; i++)
        {
            string key = listOfWorkerKeys.strings[i];
            //workerSpawner.SpawnWorker(key);
        }

    }

    public void LevelUpTeam(TShirtsColor shirtsColor) //after winning miniGame
    {
        switch (shirtsColor)
        {
            case TShirtsColor.Red:
                if (RedWorkers != null)
                {
                    foreach (var worker in RedWorkers)
                    {
                        if (worker.level >= 6)
                            worker.LevelUp();
                    }
                }
                break;

            case TShirtsColor.Green:
                if (GreenWorkers != null)
                {
                    foreach (var worker in GreenWorkers)
                    {
                        if (worker.level >= 6)
                            worker.LevelUp();
                    }
                }
                break;

            case TShirtsColor.Yellow:
                if (YellowWorkers != null)
                {
                    foreach (var worker in YellowWorkers)
                    {
                        if (worker.level >= 6)
                            worker.LevelUp();
                    }
                }
                break;

            case TShirtsColor.Blue:
                if (BlueWorkers != null)
                {
                    foreach (var worker in BlueWorkers)
                    {
                        if (worker.level >= 6)
                            worker.LevelUp();
                    }
                }
                break;
        }
    }

    public void ChangeTotalRedColor()
    {
        if (RedColorOverSix > 0)
            companyMoneyUpdates_SO.playForRedTeam = 500 * (TotalRedColor) / (RedColorOverSix) + ((factory_SO.companyLevel - 1) * 100);
    }

    public void ChangeTotalYellowColor()
    {
        if (YellowColorOverSix > 0)
            companyMoneyUpdates_SO.playForYellowTeam = 500 * (TotalYellowColor) / (YellowColorOverSix) + ((factory_SO.companyLevel - 1) * 100);
    }

    public void ChangeTotalGreenColor()
    {
        if (GreenColorOverSix > 0)
            companyMoneyUpdates_SO.playForGreenTeam = 500 * (TotalGreenColor) / (GreenColorOverSix) + ((factory_SO.companyLevel - 1) * 100);
    }

    public void ReturnFromRedGame()
    {
        print("Returned from Red game.");
        foreach (Worker worker in RedWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    print("find Red worker with state in mini game");
                    worker.LevelUp();
                    worker.PlayerWon();
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    ReturnFromOrientationGame(worker);
                }
            }
        }
    }

    public void ReturnFromYellowGame()
    {
        print("Returned from Yellow game.");
        foreach (Worker worker in YellowWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    print("find Yellow worker with state in mini game");
                    worker.LevelUp();
                    worker.PlayerWon();
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    ReturnFromOrientationGame(worker);
                }
            }
        }
    }

    public void ReturnFromGreenGame()
    {
        print("Returned from Green game.");
        foreach (Worker worker in GreenWorkers)
        {
            print(worker.workerState + " " + workersInOrientation.Contains(worker.gameObject));

            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    print("find Green worker with state in mini game");
                    worker.LevelUp();
                    worker.PlayerWon();
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    ReturnFromOrientationGame(worker);
                }
            }

        }
    }

    public void ReturnFromBlueGame()
    {
        print("Returned from Blue game.");
        foreach (Worker worker in BlueWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    print("find Blue worker with state in mini game");
                    worker.LevelUp();
                    worker.PlayerWon();
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    ReturnFromOrientationGame(worker);
                }
            }
        }
    }

    public void RedBackToNormal()
    {
        print("Red Back To Normal");

        foreach (Worker worker in RedWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    worker.workerState = WorkerState.Working;
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    worker.workerState = WorkerState.Idle;
                }
            }
        }

    }

    public void YellowBackToNormal()
    {
        print("Yellow Back To Normal");

        foreach (Worker worker in YellowWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    worker.workerState = WorkerState.Working;
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    worker.workerState = WorkerState.Idle;
                }
            }
        }

    }

    public void GreenBackToNormal()
    {
        print("Green Back To Normal");

        foreach (Worker worker in GreenWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    worker.workerState = WorkerState.Working;
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    worker.workerState = WorkerState.Idle;
                }
            }
        }

    }

    public void BlueBackToNormal()
    {
        print("Blue Back To Normal");

        foreach (Worker worker in BlueWorkers)
        {
            if (worker.workerState == WorkerState.InMiniGame)
            //if (worker.workerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Win"))
            {
                if (!(workersInOrientation.Contains(worker.gameObject)))
                {
                    worker.workerState = WorkerState.Working;
                }
                else if (workersInOrientation.Contains(worker.gameObject))
                {
                    worker.workerState = WorkerState.Idle;
                }
            }
        }


    }

    //public void ReturnFromOrientationGame()
    //{
    //    print("count in orientation: "+ workersInOrientation.Count);
    //    foreach (GameObject workerGO in workersInOrientation)
    //    {
    //        Worker worker;
    //        worker = workerGO.GetComponent<Worker>();
    //        if (worker.workerState == WorkerState.InMiniGame)
    //        {
    //            //worker.LevelUp();
    //            //worker.PlayerWon();
    //            print("Worker in Orientation has been accepted.");
    //        }
    //    }
    //}

    public void ReturnFromOrientationGame(Worker worker)
    {
        worker.LevelUp(); //is the worker level increase when worker accepted?

        assemblyLineManager.AddNewWorkerToAssemb(worker);
        print(worker.name + " has been accepted");

        worker.PlayerWon();
        //assemblyLineManager.AddNewWorkerToAssemb(worker);
        //print(worker.name + " has been accepted");
       // worker.gameObject.SetActive(false);
    }

    //public void ChangeTotalBlueColor()
    //{
    //    if (BlueColorOverSix > 0)
    //        companyMoneyUpdates_SO.playForBlueTeam = 500 * (TotalBlueColor) / (BlueColorOverSix) + ((factory_SO.companyLevel - 1) * 100);
    //}
}
