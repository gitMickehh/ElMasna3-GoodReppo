using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    public PlayerPrefsRemover_SO playerPrefsRemover_SO;
    public Play play;

    public void OnRestartButtonClicked()
    {
        playerPrefsRemover_SO.DeletePlayerPrefs();
        play.OnPlayButtonClicked();
    }
}
