using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballObstacle : MonoBehaviour {

    public ScriptableInt_SO ballCount;
    public ScriptableInt_SO ballsDestoryed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pinball_Ball")
        {
            Destroy(collision.gameObject);

            ballsDestoryed.intValue++;
            ballCount.intValue--;
        }
    }
}
