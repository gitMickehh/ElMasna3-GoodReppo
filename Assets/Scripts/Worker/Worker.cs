﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public Worker_SO WorkerStats;
    [Tooltip("It adds itself")]
    public WorkerManager workerManager;

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

    [Range(0,100)]
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

    void Start()
    {
        //var m = Instantiate(ModelOfWorker, this.transform);
        //m.layer = 8; //worker layer
        //meshRenderers = m.GetComponentsInChildren<MeshRenderer>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        workerManager = GameObject.FindGameObjectWithTag("WorkerManager").GetComponent<WorkerManager>();

        GenerateWorker();
    }

    public void GenerateWorker()
    {
        gender = WorkerStats.RandomizeGender();
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

        transform.name = FullName;

        AddToColorList();
    }
    
    public void AddComplaint()
    {
        Complaints_SO comp = complaintsManager_SO.GenerateRandomComplaint();
        complaints.Add(comp);
    }

    public void LevelUp()
    {
        print("LevelUp Event has been invoked");
        level++;
        if(coolDownTime != 0.1)
        {
            coolDownTime -= decreaseCoolDownTimeBy;
        }

        //when adding machine class 
        //if(workingSpeed <= MachineTimespeed-constant)
        workingSpeed += increaseWorkingSpeedBy;
        movementSpeed += increaseWorkingSpeedBy;
    }
    
    public void AssignWorker(Transform position)
    {
        transform.position = position.position;
    }

    public override string ToString()
    {
        return FullName + ", Gender: " + gender.ToString() 
            + "\n level: " + level;
    }

    void AddToColorList()
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

}