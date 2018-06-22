using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour {
    public Vector3 startPlace;
    public bool swiped;
    public GameEvent_SO moneyCatchedEvent;

	void Start ()
    {
        startPlace = transform.position;
        swiped = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Money" && transform.childCount == 0 && !(other.transform.parent.CompareTag("Thief")) && 
            !(swiped))
        {
            //print("catched money.");
            other.gameObject.transform.SetParent(transform);
            //other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            moneyCatchedEvent.Raise();
        }
    }

    public void StopSeeking()
    {
        GetComponent<SeekMoney>().enabled = false;
    }

    public void WhenArrested()
    {
        //print("When Arrested");
        StopSeeking();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }
}
