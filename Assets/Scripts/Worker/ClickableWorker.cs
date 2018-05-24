using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWorker : MonoBehaviour {

    Worker worker;
    public Transform cameraPos;
    [Tooltip("It finds itself, don't add")]
    public UI_WorkerScript workerUI;

    private void Start()
    {
        worker = GetComponent<Worker>();

        // hmm
        if(workerUI == null)
        {
            workerUI = FindObjectOfType<UI_WorkerScript>();
        }

    }

    private void OnMouseDown()
    {
        Debug.Log(worker.FullName);

        workerUI.OpenPanel(worker, cameraPos);

    }

}
