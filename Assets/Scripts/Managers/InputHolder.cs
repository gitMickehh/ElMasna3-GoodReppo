    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHolder : MonoBehaviour {

    [SerializeField]
    FloorManager fm;

    NavUpDown cameraNavigation;

    //public TextMeshPro debugTest;

    private void Start()
    {
        cameraNavigation = FindObjectOfType<NavUpDown>();
        fm = FindObjectOfType<FloorManager>();
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            var finger = Input.touches;
            if (finger[0].phase == TouchPhase.Stationary || finger[0].phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(new Vector3(finger[0].position.x, finger[0].position.y));
                RaycastHit info;
                if (Physics.Raycast(ray, out info, 300))
                {
                    //debugTest.text = "hit: " + info.collider.tag;

                    if (info.collider.tag == "Worker")
                    {
                        //debugTest.text = "YEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEES";
                        ClickableWorker cw = info.collider.gameObject.GetComponent<ClickableWorker>();
                        cw.ClickWorker();
                    }
                }
            }
        }
    }


    public void SetFloorTouchActive(bool floorTouchOn)
    {
        //fm.SetFloorTouchActive(floorTouchOn);
        fm.currentFloorSelected.GetComponent<FloorRotation>().enabled = floorTouchOn;
    }

    public void SetCameraTouchActive(bool cameraTouchOn)
    {
        cameraNavigation.enabled = cameraTouchOn;
    }

}
