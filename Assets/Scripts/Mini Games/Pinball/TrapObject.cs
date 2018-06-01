using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObject : MonoBehaviour {

    [SerializeField]
    float trapPushStrength = 100;

    [SerializeField]
    float triggerWaitTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pinball_Ball")
        {
            var ballScript = collision.gameObject.GetComponent<BallControl>();
            ballScript.PushBall(new Vector3(0, trapPushStrength, 0) * (-1), triggerWaitTime);
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
