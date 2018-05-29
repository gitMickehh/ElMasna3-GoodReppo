using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingForFloor : MonoBehaviour {

    public FloorManager floorManager;
    
    //Vector3 target;
    public LayerMask floorLayer;

    bool moving;

    float shootingTime = 0;

    private void FixedUpdate()
    {



        if (moving)
        {
            shootingTime += Time.fixedDeltaTime;

            if (shootingTime >= 0.5f)
            {
                moving = false;
                shootingTime = 0;
            }
            else
            {
                ShootRaysFixedUpdate();
            }
        }
    }

    public void ShootRays()
    {
        moving = true;
        shootingTime = 0;
    }

    void ShootRaysFixedUpdate()
    {
        var targetS = new Vector3(Screen.width / 2, Screen.height / 2);
        var r = Camera.main.ScreenPointToRay(targetS);

        RaycastHit info;
        Physics.Raycast(r,out info, 150, floorLayer);
        if(info.collider != null)
        {
            //Debug.Log("hit floor :)");
            floorManager.UpdateFloorSelected(info.collider.gameObject);
        }

    }

}
