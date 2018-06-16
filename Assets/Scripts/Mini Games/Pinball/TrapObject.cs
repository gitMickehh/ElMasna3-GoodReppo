using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ForceDirection { Up, Down, Right, Left}

public class TrapObject : MonoBehaviour {

    public ForceDirection directionOfHit;

    [SerializeField]
    float trapPushStrength = 100;

    [SerializeField]
    float triggerWaitTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pinball_Ball")
        {
            var ballScript = collision.gameObject.GetComponent<BallControl>();

            switch (directionOfHit)
            {
                case ForceDirection.Up:
                    ballScript.PushBall(new Vector3(0, trapPushStrength, 0), triggerWaitTime);
                    break;
                case ForceDirection.Down:
                    ballScript.PushBall(new Vector3(0, trapPushStrength, 0) * (-1), triggerWaitTime);
                    break;
                case ForceDirection.Right:
                    ballScript.PushBall(new Vector3(trapPushStrength, 0, 0), triggerWaitTime);
                    break;
                case ForceDirection.Left:
                    ballScript.PushBall(new Vector3(trapPushStrength, 0, 0) * (-1), triggerWaitTime);
                    break;
                default:
                    break;
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pinball_Ball")
        {
            //var collisionRB = collision.gameObject.GetComponent<Rigidbody2D>();
            //StopCoroutine(PushBall(collisionRB));

            var ballScript = collision.gameObject.GetComponent<BallControl>();
            ballScript.CancelPushBall();
        }
    }
    
}
