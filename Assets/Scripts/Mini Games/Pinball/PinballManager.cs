using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinballManager : MonoBehaviour {

    PinballEntrance pbEntrance;

    [SerializeField]
    int ballsToShoot = 5;

    [Header("Balls")]
    public ScriptableInt_SO ballsCount;
    public ScriptableInt_SO ballsScored;
    public ScriptableInt_SO ballsDestroyed;

    [Header("UI")]
    public Image gameStartPanel;
    public Image gameResultPanel;
    public Text gameResultText;
    bool winFlag = false;

    [Header("Goal")]
    public Transform goalPosition;

    bool gameStarted = false;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        pbEntrance = FindObjectOfType<PinballEntrance>();
    }

    void Start () {

        FindObjectOfType<GoalControl>().transform.position = goalPosition.position;
        gameResultPanel.gameObject.SetActive(false);
        //to start game
        //ShootBalls();
    }

    public void StartGame()
    {
        //count down

        gameStarted = true;
        gameStartPanel.gameObject.SetActive(false);
        ShootBalls();
    }

    private void Update()
    {
        if(gameStarted)
        {
            if (ballsCount.intValue <= 0 && !winFlag)
            {
                WinState(CheckWin());
                winFlag = true;
            }
        }
        
    }

    public void ShootBalls()
    {
        pbEntrance.ShootBalls(ballsToShoot);
    }

    private bool CheckWin()
    {
        if (ballsCount.intValue <= 0)
            return true;
        else
            return false;
    }

    private void WinState(bool winBool)
    {
        gameResultPanel.gameObject.SetActive(true);

        if (winBool)
        {
            //gameResultText.text = "أنت كسبت";
            gameResultText.text = "ﺕﺮﺴﺧ" + "\n" + "...ﻖﺣﻻ ﺖﻗﻭ ﻰﻓ ﺔﻟﻭﺎﺤﻤﻟﺍ ﺪﻋﺍ";
        }
        else
        {
            //gameResultText.text = "أنت خسرت";
            gameResultText.text = "!! ﺖﺤﺠﻧ" + "\n" + "ﺓءﺎﻔﻛ ﺮﺜﻛﺍ ﻞﻣﺎﻌﻟﺍ ﻥﻻﺍ";
        }
    }
}
