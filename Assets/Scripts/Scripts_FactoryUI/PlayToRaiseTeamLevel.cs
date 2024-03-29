﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayToRaiseTeamLevel : MonoBehaviour {

    public GameObject panel;
    public GameObject payButton;
    public int index;

    public Factory_SO Factory_SO;

    [Header("Events")]
    public GameEvent_SO miniGameStarted;

	void Start () {
        panel.SetActive(false);
    }
	

    public void ActivatePanel(int no)
    {
        panel.gameObject.SetActive(true);
        panel.GetComponent<PanelTxt>().SetText(no);
        payButton.GetComponent<PayButton>().SetText(no);
        index = no;
        print("button clicked");
    }

    public void PlayGame()
    {
        switch (index)
        {
            case 0:
                Factory_SO.TeamLevelUp(0); //yellow pinball
                StartCoroutine(LoadScene(2));
                break;
            case 1:
                Factory_SO.TeamLevelUp(1); //red thief
                StartCoroutine(LoadScene(3));
              
                break;
            //case 2:
            //    Factory_SO.TeamLevelUp(2);
            //    SceneManager.LoadScene(3);
            //    break;
            //case 3:
            //    Factory_SO.TeamLevelUp(3);
            //    SceneManager.LoadScene(4);
            //    break;
            default:
                print("LoadSceneMode of index" + index);
                break;
        }

    }

    private IEnumerator LoadScene(int scenenum)
    {
        yield return new WaitForEndOfFrame();

        miniGameStarted.Raise();
        SceneManager.LoadSceneAsync(scenenum, LoadSceneMode.Additive);
    }
}
