using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorkerPositioningAtMachine : MonoBehaviour {

    public Transform positionTrial;

    private void Start()
    {
        PositionWorker(positionTrial);
    }
    public void PositionWorker(Transform position)
    {
        transform.position = position.position;
    }
}
