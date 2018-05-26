using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour {

    //public GameObject WorkerPrefab;
    public Worker_SO workerStats;

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
        Gender g = workerStats.GetGender();
        var WorkerPrefab = workerStats.GetWorkerPrefab(g);

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

    public void OnEndDay()
    {
        numberOfWorkersInADay = 0;
    }

}
