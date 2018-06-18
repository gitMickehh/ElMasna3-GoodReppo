using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    public PlayerPrefsRemover_SO playerPrefsRemover_SO;
    public LevelLoader levelLoader;


    public void OnRestartButtonClicked()
    {
        playerPrefsRemover_SO.DeletePlayerPrefs();
        levelLoader.LoadLevel(1);
    }
}
