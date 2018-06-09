using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject setOfMoney;
    public Text money;
    public Text countDown;
    public float gameDuration;

    [Header("Events")]
    public GameEvent_SO timeIsUpEvent;
    public GameEvent_SO gameOverEvent;
    public GameEvent_SO whenYellowWin;
    public GameEvent_SO whenGreenWin;
    public GameEvent_SO whenYellowLose;
    public GameEvent_SO whenGreenLose;
    public GameEvent_SO miniGameEndedEvent;

    public GameObject panel;
    public GameObject goldImage;
    bool won;

    private void Start()
    {
        gameDuration = 60;
        money.text = (setOfMoney.transform.childCount * SetOfMoney.moneyValue).ToString();
        StartCoroutine("CountDown");

    }

    public IEnumerator CountDown()
    {
        while (true)
        {
            countDown.text = gameDuration.ToString();
            yield return new WaitForSeconds(1);
            gameDuration--;
            if (gameDuration == 0)
            {
                timeIsUpEvent.Raise();
            }
        }
    }

    public void UpdateMoney()
    {
        money.text = (setOfMoney.transform.childCount * SetOfMoney.moneyValue).ToString();
        if (setOfMoney.transform.childCount == 0)
        {
            timeIsUpEvent.Raise();
        }
    }

    public void OnGameOver()
    {
        StopCoroutine("CountDown");
        panel.SetActive(true);
        if (setOfMoney.transform.childCount == 0)
        {
            panel.GetComponentInChildren<Text>().text = "Game Over";
            won = false;
           // SceneManager.UnloadSceneAsync(3);
            //gameOverEvent.Raise();
        }
        else
        {
            panel.GetComponentInChildren<Text>().text = "You Win";
            goldImage.SetActive(true);
            goldImage.GetComponentInChildren<Text>().text = money.text;
            won = true;
           // SceneManager.UnloadSceneAsync(3);
            //winnigEvent.Raise();

        }
    }

    public void BackToFactory()
    {
        if (won)
        {
            print("Won true.");
            print("Yellow listeners count = " + whenYellowWin.listeners.Count);
            print("Green listeners count = " + whenGreenWin.listeners.Count);
            whenYellowWin.Raise();          
            whenGreenWin.Raise();          
        }

        else
        {
            whenYellowLose.Raise();
            whenGreenLose.Raise();
        }
        miniGameEndedEvent.Raise();
        SceneManager.UnloadSceneAsync(3);
    }


}
