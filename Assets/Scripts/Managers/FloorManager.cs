using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    public Factory_SO Factory_SO;

    [Header("Floor")]
    public GameObject FloorPrefab;
    public List<FloorRotation> floorsList;
    public FloorRotation TopFloor;

    [Header("Camera")]
    public CameraNavigation_SO CameraNavigator;
    public GameObject currentFloorSelected;

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
    }

}
