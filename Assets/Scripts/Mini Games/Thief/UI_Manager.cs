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
    //public GameObject goldImage;
    bool won;
    int count;

    bool gameStarted = false;

    private void Start()
    {
        gameDuration = 30;
        count = setOfMoney.transform.childCount;
       
    }

    public void StartGame()
    {
        gameStarted = true;
        money.text = (count * SetOfMoney.moneyValue).ToString();
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
        if(gameStarted)
        {
            count--;
            money.text = (count * SetOfMoney.moneyValue).ToString();
            //(setOfMoney.transform.childCount * SetOfMoney.moneyValue).ToString();
            //if (setOfMoney.transform.childCount == 0)
            //{
            //    timeIsUpEvent.Raise();
            //}
            if (count == 0)
            {
                timeIsUpEvent.Raise();
            }
        }
       
    }

    public void OnGameOver()
    {
        StopCoroutine("CountDown");
        panel.SetActive(true);
        if (setOfMoney.transform.childCount == 0)
        {
            //panel.GetComponentInChildren<Text>().text = "ﺕﺮﺴﺧ"+"\n"+"...ﻖﺣﻻ ﺖﻗﻭ ﻰﻓ ﺔﻟﻭﺎﺤﻤﻟﺍ ﺪﻋﺍ";
            panel.GetComponentInChildren<Text>().text = "You lost :(";
            won = false;
           // SceneManager.UnloadSceneAsync(3);
            //gameOverEvent.Raise();
        }
        else
        {
            //panel.GetComponentInChildren<Text>().text = "!! ﺖﺤﺠﻧ" +"\n"+ "ﺓءﺎﻔﻛ ﺮﺜﻛﺍ ﻞﻣﺎﻌﻟﺍ ﻥﻻﺍ";
            panel.GetComponentInChildren<Text>().text = "you won!\n now your worker is more skilled!";
            //goldImage.SetActive(true);
            //goldImage.GetComponentInChildren<Text>().text = money.text;
            won = true;
           // SceneManager.UnloadSceneAsync(3);
            //winnigEvent.Raise();

        }
    }

    public void BackToFactory()
    {
        if (won)
        {
            //print("Won true.");
            //print("Yellow listeners count = " + whenYellowWin.listeners.Count);
            //print("Green listeners count = " + whenGreenWin.listeners.Count);
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
