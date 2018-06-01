using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour {

    public GameEvent_SO miniGameEndedEvent;

    public ScriptableInt_SO ballCount;
    public ScriptableInt_SO ballsScored;


    private void OnMouseDown()
    {
        miniGameEndedEvent.Raise();

        SceneManager.UnloadSceneAsync(1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pinball_Ball")
        {
            Debug.Log("Goal");
            Destroy(collision.gameObject);

            ballCount.intValue--;
            ballsScored.intValue++;
        }
    }

}
