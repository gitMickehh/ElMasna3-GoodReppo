using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WorkerScript : MonoBehaviour {

    //Worker worker;

    [Header("UI Elements")]
    public RawImage workerImage;
    public Text workerName;
    public Text workerLevel;
    public Text workerEmotion;
    public Text workerDayOff;
    public Text workerMedicalState;

    public Button[] daysOfTheWeek;

    [Header("Camera")]
    public Camera UICamera;

    //UI Animation
    public Animator animatorController;

    [Header("Swipe Controls")]
    public float swipeCloseSpeed = 5;

    private void Start()
    {
        UICamera.enabled = false;
        animatorController = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }

        if (Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);

            if (touchZero.phase == TouchPhase.Moved)
            {
                float touchZeroPrevPos = touchZero.position.x - touchZero.deltaPosition.x;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = touchZeroPrevPos;
                float touchDeltaMag = touchZero.position.x;

                if(touchDeltaMag > swipeCloseSpeed)
                {
                    ClosePanel();
                }
            }
        }

    }

    public void OpenPanel(Worker w, Transform cameraPos)
    {
        //get worker data
        FillWorkerData(w);
        MoveCamera(cameraPos);

        //animate in
        animatorController.SetBool("WorkerClicked", true);
    }

    public void ClosePanel()
    {
        //animate out
        animatorController.SetBool("WorkerClicked", false);

        //destroyCamera
        ClearCamera();
    }

    public void FillWorkerData(Worker w)
    {
        workerName.text = w.FullName;
        workerLevel.text = w.level.ToString();

        //before filling traits, check their level
        if(w.level >= 6)
        {
            workerEmotion.text = w.emotion.ToString();
            workerDayOff.text = w.favDayOff.ToString();
            workerMedicalState.text = w.medicalState.ToString();
        }
        else if (w.level >= 3)
        {
            workerEmotion.text = w.emotion.ToString();
            workerDayOff.text = "???";
            workerMedicalState.text = w.medicalState.ToString();
        }
        else if(w.level >= 1)
        {
            workerEmotion.text = w.emotion.ToString();
            workerDayOff.text = "???";
            workerMedicalState.text = "???";
        }
        else
        {
            workerEmotion.text = "???";
            workerDayOff.text = "???";
            workerMedicalState.text = "???";
        }
        
    }

    private void MoveCamera(Transform CameraPosition)
    {
        UICamera.enabled = true;

        UICamera.transform.position = CameraPosition.position;
        UICamera.transform.rotation = CameraPosition.rotation;
    }

    private void ClearCamera()
    {
        //workerImage.texture = null;
        UICamera.enabled = false;
    }

}
