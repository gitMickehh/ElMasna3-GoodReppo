using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour {

    public GameEvent_SO miniGameEndedEvent;

    private void OnMouseDown()
    {
        miniGameEndedEvent.Raise();

        SceneManager.UnloadSceneAsync(1);
    }
}
