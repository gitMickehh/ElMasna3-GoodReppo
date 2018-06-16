using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBallControl : MonoBehaviour {

    public Transform ballInstantiationPosition;
    BallControl[] ballsInGame;
    public float PushMagnitude = 5;

    void FillBalls()
    {
        ballsInGame = ballInstantiationPosition.GetComponentsInChildren<BallControl>();
    }

    /*public void PushAllBalls(ForceDirection directionOfPush)
    {
        switch (directionOfPush)
        {
            case ForceDirection.Up:
                Debug.Log("up");
                break;
            case ForceDirection.Down:
                break;
            case ForceDirection.Right:
                break;
            case ForceDirection.Left:
                break;
        }
    }*/

    public void PushAllBalls(string direction)
    {
        FillBalls();
        Vector3 pushForce = Vector3.zero;

        switch (direction)
        {
            case "up":
                pushForce = Vector3.up * PushMagnitude;
                break;
            case "down":
                pushForce = Vector3.up * -PushMagnitude;
                break;
            case "right":
                pushForce = Vector3.right * PushMagnitude;
                break;
            case "left":
                pushForce = Vector3.right * -PushMagnitude;
                break;
        }

        for (int i = 0; i < ballsInGame.Length; i++)
        {
            ballsInGame[i].PushBall(pushForce,0);
        }
    }



}
