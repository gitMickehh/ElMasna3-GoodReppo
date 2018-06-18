using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotation : MonoBehaviour {

    public float SwipeSpeed = .06f;
    public float swipeThreshold = 200;

    [Header("Tutorial")]
    public GameEvent_SO rotationTutorialDone;
    bool tutorialCheck = false;

    void Update()
    {

        //if (Input.touchCount == 1 && touching)
        if (Input.touchCount == 1)
            {
            Touch touchZero = Input.GetTouch(0);

            if (touchZero.phase == TouchPhase.Began)
            {
                //Debug.Log("tap");
            }

            if (touchZero.phase == TouchPhase.Moved)
            {
                float touchZeroPrevPos = touchZero.position.x - touchZero.deltaPosition.x;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = touchZeroPrevPos;
                float touchDeltaMag = touchZero.position.x;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                float newY = deltaMagnitudeDiff * SwipeSpeed;

                //to make sure the delta isn't too small
                if (Mathf.Abs(deltaMagnitudeDiff) >= 1)
                {
                    transform.Rotate(new Vector3(0, newY, 0));
                }

                if(!tutorialCheck)
                {
                    DoTutorial();
                }

            }
        }
    }

    void DoTutorial()
    {
        if (PlayerPrefs.HasKey("firstTime"))
        {
            if (PlayerPrefs.GetInt("firstTime") != 2)
            {
                rotationTutorialDone.Raise();
                PlayerPrefs.SetInt("firstTime", 2);
            }
            else
                tutorialCheck = true;
        }
        else
        {
            rotationTutorialDone.Raise();
            PlayerPrefs.SetInt("firstTime", 2);
            tutorialCheck = true;
        }
    }

    /*void FixedUpdate () {

        if(Input.touchCount == 1 && touching)
        {
            Touch touchZero = Input.GetTouch(0);

            if (touchZero.phase == TouchPhase.Began)
            {
                Debug.Log("tap");
                //rb.AddTorque(-torque, ForceMode.Impulse);
                //rb.angularVelocity = new Vector3();
            }

            if (touchZero.phase == TouchPhase.Moved)
            {
                //Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
               float touchZeroPrevPos = touchZero.position.x - touchZero.deltaPosition.x;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = touchZeroPrevPos;
                float touchDeltaMag = touchZero.position.x;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                //this.transform.Rotate(new Vector3(0, deltaMagnitudeDiff * SwipeSpeed, 0));
                //rb.transform.Rotate(new Vector3(0, deltaMagnitudeDiff * SwipeSpeed, 0));

                float newY = deltaMagnitudeDiff * SwipeSpeed + Mathf.Sign(deltaMagnitudeDiff)* 10;
                //float newY = deltaMagnitudeDiff * SwipeSpeed;
                
                //to make sure the delta isn't too small
                if (Mathf.Abs(deltaMagnitudeDiff) >= 1)
                {
                    torque = new Vector3(0, newY, 0);
                    rb.AddTorque(torque, ForceMode.Impulse);
                    //rb.transform.Rotate(new Vector3(0, newY, 0));
                }
                //rb.AddForce(new Vector3(newY, 0, newY));
            }

            

        }

        //rb.AddTorque(new Vector3(0, 180, 0));
        //Debug.Log(rb.transform.rotation);

    }
    */


    /*private void OnMouseDown()
    {
        //touching = true;
        Debug.Log("TOUCHED FLOOR!");
    }*/

    /*
     * private void OnMouseUp()
    {
        //touching = false;
    }
    */


}
