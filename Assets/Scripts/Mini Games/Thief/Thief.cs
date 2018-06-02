using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour {
    public Vector3 startPlace;
    public GameEvent_SO moneyCatchedEvent;

	void Start ()
    {
        startPlace = transform.position;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Money" && transform.childCount == 0 && !(other.transform.parent.CompareTag("Thief")))
        {
            print("catched money.");
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            moneyCatchedEvent.Raise();
        }
    }

    public IEnumerator DestroyThief()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void StopSeeking()
    {
        GetComponent<SeekMoney>().enabled = false;
        GetComponent<TouchManager>().enabled = false;
    }
}
