using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWorker : MonoBehaviour {

    Worker worker;
    public Transform cameraPos;
    [Tooltip("It finds itself, don't add")]
    public UI_WorkerScript workerUI;

    [Header("Tutorial")]
    public GameEvent_SO ClickTutorialEvent;

    private void Start()
    {
        worker = GetComponent<Worker>();

        if(workerUI == null)
        {
            workerUI = FindObjectOfType<UI_WorkerScript>();
        }

    }

    public void ClickWorker()
    {
        Debug.Log(worker.FullName);
        workerUI.OpenPanel(worker, cameraPos);

        ClickTutorialEvent.Raise();
    }

}
