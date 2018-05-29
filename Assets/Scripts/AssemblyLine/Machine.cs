using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    [Header("Machine")]
    public Machine_SO machineBase;
    //[SerializeField]
    //public static float DurationInMinutes = 2f;
    public Transform workerPosition;

    [Header("Worker On Task")]
    public Worker worker;
    
    public float OverallTimeSeconds
    {
        get
        {
            return (machineBase.DurationInMinutes * 60) / worker.workingSpeed;
        }
    }

    public IEnumerator ActivateMachine()
    {
        yield return new WaitForSeconds(OverallTimeSeconds);

    }

}
