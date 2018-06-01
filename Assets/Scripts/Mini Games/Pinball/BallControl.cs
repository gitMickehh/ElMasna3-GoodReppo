using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    Rigidbody2D my_body;

    Vector2 speed;
    public float speedControl = 10;

    Queue<Coroutine> coroutinePushes;
    
    private void Start()
    {
        my_body = GetComponent<Rigidbody2D>();
        coroutinePushes = new Queue<Coroutine>();
    }

    void Update()
    {
        speed = Input.acceleration;
    }

    private void FixedUpdate()
    {
        my_body.AddForce(speed * speedControl);
    }

    public void PushBall(Vector3 trapPushStrength, float triggerWaitTime)
    {
        var x = StartCoroutine(PushBallCo(trapPushStrength,triggerWaitTime));

        coroutinePushes.Enqueue(x);
    }

    public void CancelPushBall()
    {
        var x = coroutinePushes.Dequeue();

        StopCoroutine(x);
    }


    IEnumerator PushBallCo(Vector3 trapPushStrength, float triggerWaitTime)
    {
        yield return new WaitForSeconds(triggerWaitTime);

        my_body.AddForce(trapPushStrength);
    }

}
