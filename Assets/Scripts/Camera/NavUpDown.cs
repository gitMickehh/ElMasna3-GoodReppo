using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavUpDown : MonoBehaviour
{
    public CameraNavigation_SO NavigationSpecs;

    public GameEvent_SO cameraMovedEvent;

    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);
            
            if (myTouch.phase == TouchPhase.Moved && (Mathf.Abs(myTouch.deltaPosition.y) > 10))
            {
                if ((myTouch.deltaPosition.y > 5) && ((transform.position.y - 0.5f) >= NavigationSpecs.MinimumYPosition))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                }
                else if ((myTouch.deltaPosition.y < 5) && ((transform.position.y + 0.5f) <= NavigationSpecs.MaximumYPosition))
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

                cameraMovedEvent.Raise();
            }

        }
    }
}
