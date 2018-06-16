using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    [Header("Events")]
    public GameEvent_SO Tut_RotateBuilding;
    public GameEvent_SO Tut_TouchWorker;
    public GameEvent_SO Tut_PlayMiniGame;

    [Header("Worker Manager")]
    public Transform OrientationTransform;
    Worker[] workersInOrientation;

    [Header("UI")]
    public GameObject RotationArrowsPanel;
    public Image PointingHand;

    bool rotatedBuilding = false;
    bool touchedWorker = false;
    bool miniGamePlayed = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("firstTime"))
        {
            if (PlayerPrefs.GetInt("firstTime") == 1 || PlayerPrefs.GetInt("firstTime") == 2)
            {

            }
            else
                StartCoroutine(StartTutorial());
        }
        else
        {
            StartCoroutine(StartTutorial());
            PlayerPrefs.SetInt("firstTime", 1);
        }
    }

    IEnumerator StartTutorial()
    {
        yield return null;
        Tut_RotateBuilding.Raise();
    }

    void FillInWorkers()
    {
        workersInOrientation = OrientationTransform.GetComponentsInChildren<Worker>();
    }

    public void StartRotateBuildingTut()
    {
        RotationArrowsPanel.SetActive(true);
    }

    public void StartPointingAtWorkers()
    {
        FillInWorkers();

        Vector2 workerPos = Camera.main.WorldToScreenPoint(workersInOrientation[0].gameObject.transform.position);
        PointingHand.gameObject.SetActive(true);
        PointingHand.transform.position = workerPos;

    }

    public void SetRotationDone()
    {
        rotatedBuilding = true;
        Tut_TouchWorker.Raise();
    }

    public void SetTouchedWorkerDone()
    {
        touchedWorker = true;
        Tut_PlayMiniGame.Raise();
    }

    public void SetMiniGamePlayed()
    {
        miniGamePlayed = true;
        
        //last tutorial
        enabled = false;
    }


}
