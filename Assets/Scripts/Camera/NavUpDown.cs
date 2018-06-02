using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavUpDown : MonoBehaviour
{
    public CameraNavigation_SO NavigationSpecs;
    public GameEvent_SO cameraMovedEvent;
    public ScriptableBool_SO cameraMovedBoolSO;

    public float navSpeed = 1.7f;


    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);
            
            if (myTouch.phase == TouchPhase.Moved && (Mathf.Abs(myTouch.deltaPosition.y) > 10))
            {
                if ((myTouch.deltaPosition.y > 5) && ((transform.position.y - navSpeed)  >= NavigationSpecs.MinimumYPosition))
                {
                    transform.position = new Vector3((transform.position.x), (transform.position.y - navSpeed) , transform.position.z);
                }
                else if ((myTouch.deltaPosition.y < 5) && ((transform.position.y + navSpeed) <= NavigationSpecs.MaximumYPosition))
                    transform.position = new Vector3((transform.position.x), (transform.position.y  + navSpeed) , transform.position.z);

                cameraMovedBoolSO.boolValue = true;
                cameraMovedEvent.Raise();

            }

        }
    }
}
