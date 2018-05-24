using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayToRaiseTeamLevel : MonoBehaviour {

    public GameObject panel;

	void Start () {
        panel.SetActive(false);
    }
	

    public void ActivatePanel(int index)
    {
        panel.gameObject.SetActive(true);
        panel.GetComponent<PanelTxt>().SetText(index);
        print("button clicked");
    }

    public void PlayGame(int index)
    {
        switch (index)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            default:
                SceneManager.LoadScene(1);
                break;
        }

    }

}
