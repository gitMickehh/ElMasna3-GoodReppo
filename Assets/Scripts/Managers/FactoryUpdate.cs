using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUpdate : MonoBehaviour {

    public Factory_SO Factory;
    string firstLoginFactoryJson;

    private void Start()
    {
        //loading factory
        CheckSavedAndUpdateDates();
    }

    private void OnApplicationQuit()
    {
        SaveLastTimeNow();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            CheckSavedAndUpdateDates();
        }
        else
        {
            SaveLastTimeNow();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveLastTimeNow();
        }
        else
        {
            CheckSavedAndUpdateDates();
        }
    }

    void CheckSavedAndUpdateDates()
    {
        if (PlayerPrefs.HasKey("FirstDateEver"))
        {
            //Debug.Log("has key of first");
            firstLoginFactoryJson = PlayerPrefs.GetString("FirstDateEver");
            Factory.FirstLoginTime.date = JsonUtility.FromJson<DateClass>(firstLoginFactoryJson);
            //Factory.FirstLoginTime = JsonUtility.FromJson<DateTime_SO>(firstLoginFactoryJson);
            //Debug.Log("already saved: \n"+firstLoginFactoryJson);
        }
        else
        {
            Debug.Log("No saved data for first time");
            //first time ever
            Factory.FirstLoginTime.SetTimeNow();
            firstLoginFactoryJson = JsonUtility.ToJson(Factory.FirstLoginTime.date);
            PlayerPrefs.SetString("FirstDateEver", firstLoginFactoryJson);
        }

        if (PlayerPrefs.HasKey("LastTime"))
        {
            string lastTimeJson = PlayerPrefs.GetString("LastTime");
            Factory.LastTimeLogin.date = JsonUtility.FromJson<DateClass>(lastTimeJson);
        }
        else
        {
            Debug.Log("No saved data for last time");
            //first time ever
            Factory.LastTimeLogin.SetTimeNow();
        }
    }

    void SaveLastTimeNow()
    {
        Factory.LastTimeLogin.SetTimeNow();
        string lastTimeLogin = JsonUtility.ToJson(Factory.LastTimeLogin.date);
        PlayerPrefs.SetString("LastTime", lastTimeLogin);
    }
}
