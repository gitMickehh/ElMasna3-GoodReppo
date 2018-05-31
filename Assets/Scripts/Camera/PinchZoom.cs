using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    //public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.05f;        // The rate of change of the orthographic size in orthographic mode.
    Camera camera;
    public float minOrthographicSize = 8.7f;
    public float maxOrthographicSize = 15f;

    private void Start()
    {
        camera = transform.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            
            if (camera.orthographic)
            {
                camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, minOrthographicSize);
                camera.orthographicSize = Mathf.Min(camera.orthographicSize, maxOrthographicSize);

               
            }

            //else
            //{
            //    // Otherwise change the field of view based on the change in distance between the touches.
            //    camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            //    // Clamp the field of view to make sure it's between 0 and 180.
            //    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
            //}

        }
    }
}
