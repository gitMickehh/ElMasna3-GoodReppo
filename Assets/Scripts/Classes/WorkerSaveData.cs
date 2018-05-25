using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkerSaveData{

    string FullName;
    Gender gender;
    int level;
    MiniGameLinker_SO workerColor;

    EmotionalTrait emotion;
    Day favDayOff;
    MedicalTrait medicalState;

    float happyMeter;

    List<Complaints_SO> complaints;

    public WorkerState workerState;

    public Transform workerPosition;

    public WorkerSaveData()
    {
        FullName = "Baher Maher";
        gender = Gender.MALE;
        level = 1;
        workerColor = null;
        emotion = null;
        medicalState = null;
        favDayOff = Day.Saturday;
        happyMeter = 50;
        complaints = new List<Complaints_SO>();

        workerPosition = null;
        workerState = WorkerState.Working;
    }

    public WorkerSaveData(string fullName, Gender g, int lvl, 
        MiniGameLinker_SO color, EmotionalTrait emoti, MedicalTrait med, Day favDay, 
        float happiness, List<Complaints_SO> complts)
    {
        FullName = fullName;
        gender = g;
        level = lvl;
        workerColor = color;
        emotion = emoti;
        medicalState = med;
        favDayOff = favDay;
        happyMeter = happiness;
        complaints = complts;

        workerPosition = null;
        workerState = WorkerState.Working;
    }

    public WorkerSaveData(string fullName, Gender g, int lvl,
        MiniGameLinker_SO color, EmotionalTrait emoti, MedicalTrait med, Day favDay,
        float happiness, List<Complaints_SO> complts, Transform t)
    {
        FullName = fullName;
        gender = g;
        level = lvl;
        workerColor = color;
        emotion = emoti;
        medicalState = med;
        favDayOff = favDay;
        happyMeter = happiness;
        complaints = complts;

        workerPosition = t;
    }
    
    public string FullName1
    {
        get
        {
            return FullName;
        }
    }

    public Gender Gender
    {
        get
        {
            return gender;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    public MiniGameLinker_SO WorkerColor
    {
        get
        {
            return workerColor;
        }
    }

    public EmotionalTrait Emotion
    {
        get
        {
            return emotion;
        }
    }

    public Day FavDayOff
    {
        get
        {
            return favDayOff;
        }
    }

    public MedicalTrait MedicalState
    {
        get
        {
            return medicalState;
        }

    }

    public float HappyMeter
    {
        get
        {
            return happyMeter;
        }
    }

    public List<Complaints_SO> Complaints
    {
        get
        {
            return complaints;
        }
    }
}
