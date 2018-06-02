using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    public Factory_SO Factory_SO;

    [Header("Floor")]
    public GameObject FloorPrefab;
    public FloorRotation[] floorsList;
    public FloorRotation TopFloor;

    [Header("Camera")]
    public CameraNavigation_SO CameraNavigator;
    public GameObject currentFloorSelected;

    private void Start()
    {
        UpdateFloors();

        for (int i = 0; i < floorsList.Length; i++)
        {
            floorsList[i].GetComponent<FloorRotation>().enabled = false;
        }

        UpdateFloorSelected(currentFloorSelected);
    }

    private void UpdateFloors()
    {
        floorsList = FindObjectsOfType<FloorRotation>();
    }

    public void OnClickAddFloor()
    {
        print("Add Floor.");
        Factory_SO.LevelUp();
        
        Vector3 FloorPosition = TopFloor.transform.position;
        FloorPosition.y += (29.73f);
        GameObject f = Instantiate(FloorPrefab, FloorPosition,new Quaternion());
        FloorRotation fr = f.GetComponent<FloorRotation>();
        TopFloor = fr;
        CameraNavigator.MaximumYPosition += 20f;
        

    }

    public void UpdateFloorSelected(GameObject floor)
    {
        currentFloorSelected.GetComponent<FloorRotation>().enabled = false;
        currentFloorSelected = floor;
        currentFloorSelected.GetComponent<FloorRotation>().enabled = true;

        //Debug.Log(currentFloorSelected.name);
    }

    public void SetFloorTouchActive(bool floorTouchOn)
    {
        UpdateFloors();
        for (int i = 0; i < floorsList.Length; i++)
        {
            floorsList[i].enabled = floorTouchOn;
        }

        //UpdateFloorSelected(currentFloorSelected);
    }


    public void SetCurrentFloorActive(bool floorTouchOn)
    {
        currentFloorSelected.GetComponent<FloorRotation>().enabled = floorTouchOn;
    }

}
