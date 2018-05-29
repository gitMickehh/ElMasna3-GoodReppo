using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_TouchManager : MonoBehaviour
{

    public FirstTap_SO firstTap_SO;
    public Camera camera;
    Zoom zoom;
    private void Start()
    {
        zoom = camera.gameObject.GetComponent<Zoom>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstTap_SO.CheckForDoubleTap();
                    break;
            }
        }
    }

    public void ZoomOnDoubleTap()
    {
        print("Double Tap.");
       // if (!zoom)
            StartCoroutine(zoom.Transition());
        //else
            //zoomOut
            //set zoom false
    }
}
