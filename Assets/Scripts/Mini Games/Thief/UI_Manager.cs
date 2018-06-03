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
    public GameEvent_SO timeIsUpEvent;
    public GameEvent_SO gameOverEvent;
    public GameEvent_SO winnigEvent;
    public GameObject panel;
    public GameObject goldImage;
    public WorkerInMiniGame_SO workerInMiniGame_SO;

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
            //gameOverEvent.Raise();
            workerInMiniGame_SO.workerWon = false;
        }
        else
        {
            panel.GetComponentInChildren<Text>().text = "You Win";
            goldImage.SetActive(true);
            goldImage.GetComponentInChildren<Text>().text = money.text;
            //winnigEvent.Raise();

            workerInMiniGame_SO.workerWon = true;
        }
    }

    public void BackToFactory()
    {
        SceneManager.UnloadScene(workerInMiniGame_SO.WorkerInGame.workerColor.sceneBuildIndex);
        if (workerInMiniGame_SO.workerWon)
        {
            workerInMiniGame_SO.WorkerInGame.PlayerWon();
        }
    }

}
