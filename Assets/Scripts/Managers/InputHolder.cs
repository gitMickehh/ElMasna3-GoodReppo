    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHolder : MonoBehaviour {

    [SerializeField]
    FloorRotation[] floorRotationScripts;

    [SerializeField]
    NavUpDown cameraNavigation;

    private void Start()
    {
        cameraNavigation = FindObjectOfType<NavUpDown>();
    }

    void UpdateFloorRotations()
    {
        floorRotationScripts = FindObjectsOfType<FloorRotation>();
    }

    public void SetFloorTouchActive(bool floorTouchOn)
    {
        for (int i = 0; i < floorRotationScripts.Length; i++)
        {
            floorRotationScripts[i].enabled = floorTouchOn;
        }
    }

    public void SetCameraTouchActive(bool cameraTouchOn)
    {
        cameraNavigation.enabled = cameraTouchOn;
    }

}
