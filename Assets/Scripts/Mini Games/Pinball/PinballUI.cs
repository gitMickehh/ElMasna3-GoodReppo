using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinballUI : MonoBehaviour {

    public MiniGameLinker_SO thisGame;
    public GameEvent_SO whenRedWin;
    public GameEvent_SO whenBlueWin;

    public GameEvent_SO miniGameEndedEvent;

	public void BackToFactory()
    {
        miniGameEndedEvent.Raise();
        whenRedWin.Raise();
        whenBlueWin.Raise();

        SceneManager.UnloadSceneAsync(thisGame.sceneBuildIndex);
    }
}
