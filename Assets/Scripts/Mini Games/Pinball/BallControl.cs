using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinballGoal")
        {
            Debug.Log("Goal");
            Destroy(this.gameObject);
        }
    }
}
