using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{

    public Camera thiefCam;
    public Sprite happyPolice;
    public Sprite sadPolice;

    private void Awake()
    {
        thiefCam = GameObject.FindGameObjectWithTag("ThiefCamera").GetComponent<Camera>();
    }
    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sadPolice;
        //gameObject.GetComponent<Animator>().enabled = true;
        ChangePositionRandom();
    }

    private void OnDisable()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void ChangePositionRandom()
    {
        Vector3 screenPosition = thiefCam.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), thiefCam.farClipPlane / 2));
        transform.position = screenPosition;
    }

    public void ArrestThief()
    {
        print("Arrest Thief");
        //StopAnimation();
        gameObject.GetComponent<SpriteRenderer>().sprite = happyPolice;

    }
    public void StopAnimation()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
