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
    public Image gameResultPanel;
    public TextMeshProUGUI gameResultText;
    bool winFlag = false;

    [Header("Goal")]
    public Transform goalPosition;


	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        pbEntrance = FindObjectOfType<PinballEntrance>();

        FindObjectOfType<GoalControl>().transform.position = goalPosition.position;

        gameResultPanel.gameObject.SetActive(false);

        ShootBalls();
    }

    private void Update()
    {
        if(ballsCount.intValue <= 0 && !winFlag)
        {
            WinState(CheckWin());
            winFlag = true;
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
            gameResultText.text = "You win";
        }
        else
        {
            //gameResultText.text = "أنت خسرت";
            gameResultText.text = "You lose";
        }
    }
}
