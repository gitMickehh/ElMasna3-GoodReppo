using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballEntrance : MonoBehaviour {

    public Transform entryPoint;
    public GameObject ballObject;

    public ScriptableInt_SO ballCount;

    [Header("Instance Rotation")]
    public float minimumZRotation;
    public float maximumZRotation;

    [Header("Instance Speed")]
    public float minimumForce;
    public float maximumForce;

    public void ShootBalls(int ballsCount)
    {
        for (int i = 0; i < ballsCount; i++)
        {
            var currentBall = Instantiate(ballObject, entryPoint);
            var currentBall_body = currentBall.GetComponent<Rigidbody2D>();

            Vector3 randomAngle = new Vector3(0,0,Random.Range(minimumZRotation,maximumZRotation));
            currentBall_body.transform.Rotate(randomAngle);

            currentBall_body.AddForce(currentBall_body.transform.up
                * Random.Range(minimumForce, maximumForce));

            ballCount.intValue++;
        }
    }


}
