using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour {

    public GameObject WorkerPrefab;

    [Header("Instantiation")]
    public Transform OrientationOrigin;

    [Header("Spawn Position")]
    public float radius = 100;
    public float theta = 270;

    [Header("Worker Manager Script")]
    public WorkerManager workerManager;
    int numberOfWorkersInADay = 0;
    

    private void Start()
    {
        workerManager = GetComponent<WorkerManager>();
    }

    void AddNewWorker(int index)
    {
        //angleDiff = (90 / noOfWorkers*1.0f);

        GameObject w = Instantiate(WorkerPrefab, OrientationOrigin);
        w.transform.position = new Vector3(radius * (Mathf.Cos((theta+(index* 15))*(Mathf.PI/180))),
            OrientationOrigin.position.y, -radius * (Mathf.Sin((theta + (index * 15)) * (Mathf.PI / 180))));

        Worker wo = w.GetComponent<Worker>();

        //randomly generate worker
        wo.GenerateWorker();

        workerManager.AddNewWorker(w);
    }

    public void SpawnNewWorkers(int numOfWorkers)
    {
        numberOfWorkersInADay = numOfWorkers;

        for (int i = 0; i < numOfWorkers; i++)
        {
            AddNewWorker(i);
        }
    }

    //supposed to spawn a worker in a position
    public void SpawnWorker(string key)
    {
        string saveJson = PlayerPrefs.GetString(key);
        WorkerSaveData saveData = JsonUtility.FromJson<WorkerSaveData>(saveJson);

        GameObject w = Instantiate(WorkerPrefab, saveData.workerPosition);
        //w.transform.position = new Vector3(radius * (Mathf.Cos(theta) * (Mathf.PI / 180)),
        //    OrientationOrigin.position.y, -radius * (Mathf.Sin(theta) * (Mathf.PI / 180)));

        Worker wo = w.GetComponent<Worker>();
        wo.LoadWorker(saveData);

        workerManager.AddNewWorker(w);
    }

    public void OnEndDay()
    {
        numberOfWorkersInADay = 0;
    }

}
