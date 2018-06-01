    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHolder : MonoBehaviour {

    [SerializeField]
    FloorManager fm;

    NavUpDown cameraNavigation;

    private void Start()
    {
        cameraNavigation = FindObjectOfType<NavUpDown>();
        fm = FindObjectOfType<FloorManager>();
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
