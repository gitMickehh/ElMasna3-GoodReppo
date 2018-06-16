using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArrest : MonoBehaviour
{
    public GameEvent_SO thiefGotArrested;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Something triggered in detectArrest " + collision.tag);
        if (collision.CompareTag("Thief_Police") && (collision.transform.childCount == 0) 
            && (gameObject.GetComponent<Thief>().swiped))
        {
            print("Detect Thief");
            gameObject.GetComponent<Thief>().WhenArrested();
            gameObject.transform.SetParent(collision.transform);

            thiefGotArrested.Raise();
        }
    }
}
