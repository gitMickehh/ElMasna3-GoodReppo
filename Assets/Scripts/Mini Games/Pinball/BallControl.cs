using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    Rigidbody2D my_body;

    Vector2 speed;
    public float speedControl = 10;

    private void Start()
    {
        my_body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speed = Input.acceleration;
        my_body.AddForce(speed * speedControl);
        //transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinballGoal")
        {
            Debug.Log("Goal");
            Destroy(this.gameObject);
        }
    }
}
