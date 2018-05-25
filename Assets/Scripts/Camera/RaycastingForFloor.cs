using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingForFloor : MonoBehaviour {

    public FloorManager floorManager;
    //Vector3 target;
    public LayerMask floorLayer;

    public void ShootRays()
    {
        var targetS = new Vector3(Screen.width / 2, Screen.height / 2);
        var r = Camera.main.ScreenPointToRay(targetS);

        //target = r.direction * 150;
        //Debug.DrawRay(transform.position, target, Color.red);

        RaycastHit info;
        Physics.Raycast(r,out info, 150, floorLayer);
        if(info.collider != null)
        {
            //Debug.Log("hit floor :)");
            floorManager.UpdateFloorSelected(info.collider.gameObject);
        }

    }

}
