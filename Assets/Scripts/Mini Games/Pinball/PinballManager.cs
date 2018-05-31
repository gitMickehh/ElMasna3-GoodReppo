using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballManager : MonoBehaviour {

    PinballEntrance pbEntrance;

    [SerializeField]
    int ballsToShoot = 5;

    public ScriptableInt_SO ballsCount;
    public ScriptableInt_SO ballsScored;
    public ScriptableInt_SO ballsDestroyed;

    public Transform goalPosition;

	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        pbEntrance = FindObjectOfType<PinballEntrance>();

        FindObjectOfType<GoalControl>().transform.position = goalPosition.position;

        ShootBalls();
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
}
