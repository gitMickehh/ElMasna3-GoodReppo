using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorkerState
{
    Idle,
    Working,
    InMiniGame,
    Winning,
    Complaining
}

public class Worker : MonoBehaviour
{
    [Header("Randomnes")]
    public bool isRandom = true;

    [Header("Management")]
    public Worker_SO WorkerStats;
    [Tooltip("It adds itself")]
    public WorkerManager workerManager;
    public WorkerState workerState;

    [Header("Info")]
    public string FullName;
    public Gender gender;
    public int level;
    //title for promotion?

    [Header("Color")]
    public MiniGameLinker_SO workerColor;

    [Header("Traits")]
    public EmotionalTrait emotion;
    public Day favDayOff;
    public MedicalTrait medicalState;

    //public bool workingState;

    [Range(0, 100)]
    public float happyMeter;

    [Header("Cooldown")]
    public float coolDownTime;
    public float decreaseCoolDownTimeBy = 0.01f;

    [Header("Speed")]
    public float movementSpeed;
    public float workingSpeed;
    public float increaseWorkingSpeedBy = 0.05f;

    [Header("Complaints")]
    public ComplaintsManager_SO complaintsManager_SO;
    public List<Complaints_SO> complaints;


    [Header("Model")]
    //public GameObject ModelOfWorker;
    public MeshRenderer[] meshRenderers;
    public SkinnedMeshRenderer[] skinnedMeshRenderers;

    //[Header("Events")]
    //public GameEvent_SO LevelUpEvent;

    [Header("Scriptable Objects")]
    public Factory_SO factory_SO;

    public Animator workerAnimator;
    public Machine machineAssigned;

    public float PlayingToLevelIndivCost
    {
        get
        {
            return 200 * Mathf.Pow(1.05f, level);
        }
    }

    void Awake()
    {
        //Debug.Log("I started");
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        //workerManager = GameObject.FindGameObjectWithTag("WorkerManager").GetComponent<WorkerManager>();
        workerManager = FindObjectOfType<WorkerManager>();
        workerAnimator = GetComponentInChildren<Animator>();


    }
    private void Start()
    {

        if (isRandom)
        {
            GenerateWorker();
            workerState = WorkerState.Idle;
        }
    }

    //states for worker and for animation

    public void GenerateWorker()
    {
        //gender = WorkerStats.RandomizeGender();
        FullName = WorkerStats.RandomizeName(gender);

        emotion = WorkerStats.RandomizeEmotionalTraits();
        medicalState = WorkerStats.RandomizeMedicalTraits();
        favDayOff = WorkerStats.GetRandomFavDay();

        coolDownTime = WorkerStats.CooldownTime;
        movementSpeed = WorkerStats.MovementSpeed;

        happyMeter = 50;
        level = 0;
        //workingState = false;
        workingSpeed = 1f;

        //shirt color
        workerColor = WorkerStats.RandomizeColorLinker();
        Color c = workerColor.ShirtColor;

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = c;
        }

        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            skinnedMeshRenderers[i].material.color = c;
        }

        transform.name = FullName;

        //for testing
        AddToColorList();
    }

    public void AddComplaint()
    {
        SetWorkerState(WorkerState.Complaining);
        Complaints_SO comp = complaintsManager_SO.GenerateRandomWorkerComplaint();
        complaints.Add(comp);
    }

    public void LevelUp()
    {
        print("LevelUp Event has been invoked");
        level++;
        //LevelUpEvent.Raise();
        if (coolDownTime != 0.1)
        {
            coolDownTime -= decreaseCoolDownTimeBy;
        }

        //when adding machine class 
        //if(workingSpeed <= MachineTimespeed-constant)
        workingSpeed += increaseWorkingSpeedBy;
        movementSpeed += increaseWorkingSpeedBy;
    }
    /*
    public void AssignWorker(Transform position)
    {
        transform.position = position.position;
    }
    */

    public void AssignWorker(Machine machine)
    {
        machineAssigned = machine;
        machineAssigned.worker = this;
        transform.position = machineAssigned.workerPosition.position;

        machineAssigned.SetMachineState(MachineState.Working);

        if (workerState != WorkerState.InMiniGame)
            SetWorkerState(WorkerState.Working);

    }

    public override string ToString()
    {
        return FullName + ", Gender: " + gender.ToString()
            + "\n level: " + level;
    }

    void AddToColorList()  //changed it to public
    {
        switch (workerColor.colorName)
        {
            case "yellow":
                workerManager.AddYellowWorker(this);
                break;
            case "red":
                workerManager.AddRedWorker(this);
                break;
            case "blue":
                workerManager.AddBlueWorker(this);
                break;
            case "green":
                workerManager.AddGreenWorker(this);
                break;
            default:
                break;
        }
    }

    //saving
    public void SaveWorker(string key)
    {
        WorkerSaveData saveData = new WorkerSaveData(FullName, gender, level, workerColor,
            emotion, medicalState, favDayOff, happyMeter, complaints);

        string saveJson = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(key, saveJson);

    }

    public void LoadWorker(string key)
    {
        string saveJson = PlayerPrefs.GetString(key);
        WorkerSaveData saveData = JsonUtility.FromJson<WorkerSaveData>(saveJson);

        gender = saveData.Gender;
        FullName = saveData.FullName1;

        emotion = saveData.Emotion;
        medicalState = saveData.MedicalState;
        favDayOff = saveData.FavDayOff;

        coolDownTime = WorkerStats.CooldownTime;
        movementSpeed = WorkerStats.MovementSpeed;

        happyMeter = saveData.HappyMeter;
        level = saveData.Level;

        workingSpeed = 1f;

        workerColor = saveData.WorkerColor;
        Color c = workerColor.ShirtColor;
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = c;
        }

        transform.name = FullName;

        AddToColorList();
    }

    public void LoadWorker(WorkerSaveData saveData)
    {
        gender = saveData.Gender;
        FullName = saveData.FullName1;

        emotion = saveData.Emotion;
        medicalState = saveData.MedicalState;
        favDayOff = saveData.FavDayOff;

        coolDownTime = WorkerStats.CooldownTime;
        movementSpeed = WorkerStats.MovementSpeed;

        happyMeter = saveData.HappyMeter;
        level = saveData.Level;

        workingSpeed = 1f;

        workerColor = saveData.WorkerColor;
        Color c = workerColor.ShirtColor;
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = c;
        }

        transform.name = FullName;

        AddToColorList();
    }

    //if worker is working and not in orientation, AddToColorList() after loading or after going to the state

    //happiness
    public void AddHappiness(float percentage)
    {
        happyMeter = Mathf.Clamp(happyMeter + percentage, 0, 100);
    }

    public void DecreaseHappiness(float percentage)
    {
        happyMeter = Mathf.Clamp(happyMeter - percentage, 0, 100);
    }

    public void PayForPlaying()
    {
        factory_SO.WithdrawMoney(PlayingToLevelIndivCost);
    }

    public void SetWorkerState(WorkerState state)
    {
        workerState = state;
        switch (state)
        {
            case WorkerState.Idle:
                workerAnimator.SetBool("Working", false);
                break;

            case WorkerState.Working:
                workerAnimator.SetBool("Working", true);
                break;

            case WorkerState.Winning:
                //print("winning");
                workerAnimator.SetBool("Working", false);
                workerAnimator.SetTrigger("WinTrigger");
                StartCoroutine(WaitTillWinningFinish());
                if (machineAssigned.machineState == MachineState.Broken)
                {
                    workerAnimator.SetBool("Working", false);
                    workerState = WorkerState.Idle;
                }
                else
                {
                    workerAnimator.SetBool("Working", true);
                    workerState = WorkerState.Working;
                }
                break;

            case WorkerState.Complaining:
                GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.black;
                break;

        }
    }

    IEnumerator WaitTillWinningFinish()
    {
        yield return new WaitForSeconds(3.5f);

        if (workerManager.workersInOrientation.Contains(gameObject))
        {
            gameObject.SetActive(false);
        }
    }

    public void PlayerWon()
    {
        print("Player Won.");
        SetWorkerState(WorkerState.Winning);
    }

}