using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    public GameObject FloorPrefab;
    public Factory_SO Factory_SO;

    public FloorRotation TopFloor;

    public CameraNavigation_SO CameraNavigator;

    public void OnClickAddFloor()
    {
        print("Add Floor.");
        Factory_SO.LevelUp();
        /*
        Vector3 FloorPosition = TopFloor.transform.position;

        FloorPosition.y += (2.27f * 2);

        GameObject f = Instantiate(FloorPrefab, FloorPosition,new Quaternion());

        FloorRotation fr = f.GetComponent<FloorRotation>();
        TopFloor = fr;

        CameraNavigator.MaximumYPosition += 2.5f;
        */

    }

}
