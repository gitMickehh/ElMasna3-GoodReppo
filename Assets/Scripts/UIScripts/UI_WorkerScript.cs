using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_WorkerScript : MonoBehaviour
{

    Worker worker;

    [Header("UI Elements")]
    public RawImage workerImage;
    public Text workerName;
    public Text workerLevel;
    public Text workerEmotion;
    public Text workerDayOff;
    public Text workerMedicalState;

    public Button[] daysOfTheWeek;
    public Button playButton;

    [Header("Factory")]
    public Factory_SO factory_SO;

    [Header("Camera")]
    public Camera UICamera;

    //UI Animation
    public Animator[] animatorControllers;

    [Header("Swipe Controls")]
    public float swipeCloseSpeed = 5;
    bool opened = false;
    float touchDeltaMag = 0;
    //float openTime = 0;
    //public float maxOpenTime = 0.5f;

    [Header("Events")]
    public GameEvent_SO miniGameStartedEvent;

    [Header("Manager")]
    public WorkerManager workerManager;
    public AssemblyLineManager assemblyLineManager;

    private void Start()
    {
        UICamera.enabled = false;
        animatorControllers = GetComponentsInChildren<Animator>();
        PlayButtonInteract();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }

        if (opened)
        {
                if (Input.touchCount == 1)
                {
                    Touch touchZero = Input.GetTouch(0);

                    if (touchZero.phase == TouchPhase.Moved)
                    {
                        float touchZeroPrevPos = touchZero.position.x - touchZero.deltaPosition.x;
                        touchDeltaMag = touchZero.position.x;

                        
                    }
                    if(touchZero.phase == TouchPhase.Ended)
                    {
                       if (touchDeltaMag > swipeCloseSpeed)
                            {
                                ClosePanel();
                            }
                    touchDeltaMag = 0;
                    }
                }
            
        }

    }

    public void OpenPanel(Worker w, Transform cameraPos)
    {
        print("Panel Opened");
        //get worker data
        FillWorkerData(w);
        PlayButtonInteract();
        MoveCamera(cameraPos);

        //turn off other input
        //GetComponent<UI_OpenCloseEvent>().UI_OpenEvent.Raise();

        //animate in
        animatorControllers[0].SetBool("WorkerClicked", true);
        animatorControllers[1].SetBool("WorkerClicked", true);

        opened = true;

        FindObjectOfType<FloorManager>().SetCurrentFloorActive(false);
    }

    public void ClosePanel()
    {
        //animate out
        animatorControllers[0].SetBool("WorkerClicked", false);
        animatorControllers[1].SetBool("WorkerClicked", false);

        //turn on other input
        //GetComponent<UI_OpenCloseEvent>().UI_CloseEvent.Raise();

        //clearCamera
        ClearCamera();

        opened = false;
        //openTime = 0;

        FindObjectOfType<FloorManager>().SetCurrentFloorActive(true);

    }

    public void FillWorkerData(Worker w)
    {
        worker = w;
        workerName.text = w.FullName;
        workerLevel.text = w.level.ToString();

        //before filling traits, check their level
        if (w.level >= 6)
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
        else if (w.level >= 1)
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

        UICamera.transform.parent = CameraPosition;
    }

    private void ClearCamera()
    {
        //workerImage.texture = null;
        UICamera.enabled = false;
    }

    public void PlayButtonInteract()
    {
        if(worker != null)
        {
            if (factory_SO.FactoryMoney >= worker.PlayingToLevelIndivCost)
            {
                //print("workerManager.workersInOrientation.Contains(worker.gameObject): " + workerManager.workersInOrientation.Contains(worker.gameObject));
                //print("assemblyLineManager.canAssign: " + assemblyLineManager.canAssign);
                //print("workerManager.WorkersPrefabs.Contains(worker.gameObject): "+ workerManager.WorkersPrefabs.Contains(worker.gameObject));
                if (workerManager.workersInOrientation.Contains(worker.gameObject) && assemblyLineManager.canAssign)
                {
                    print("Can Assign");
                    playButton.interactable = true;
                }
                else if (workerManager.WorkersPrefabs.Contains(worker.gameObject))
                {
                    playButton.interactable = true;
                }
                else
                    playButton.interactable = false;
            }
            else
            {
                print("Can't Assign");
                playButton.interactable = false;
            }
        }
    }

    public void PlayButton()
    {
       // print("worker: " + worker);
        worker.SetWorkerState(WorkerState.InMiniGame);
        var bIndex = worker.workerColor.sceneBuildIndex;
        //StartCoroutine(LoadSceneCo(bIndex));
        SceneManager.LoadSceneAsync(bIndex, LoadSceneMode.Additive);
        miniGameStartedEvent.Raise();

    }

    IEnumerator LoadSceneCo(int bIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(bIndex, LoadSceneMode.Additive);

        while (!op.isDone)
        {
            yield return null;
        }

    }

    public void TurnOffUI()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void ActivateAll_BackFromMiniGame()
    {
        transform.parent.gameObject.SetActive(true);
    }



}
