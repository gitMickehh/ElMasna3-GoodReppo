using System.Collections;
using UnityEngine;

public class GenerateWorkers : MonoBehaviour
{

    WorkerSpawner workerSpawner;

    private void Start()
    {
        workerSpawner = GetComponent<WorkerSpawner>();
    }

    public void GenerateNewWorkers()
    {
        int no = Random.Range(0, 6);

        Debug.Log("Workers generated = " + no);

        workerSpawner.SpawnNewWorkers(no);
    }
}