using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastingForFloor : MonoBehaviour {

    //public Text text1;
    //public Text text2;
    //public Text text3;

    public FloorManager floorManager;
    

    //Vector3 target;
    public LayerMask floorLayer;

    //bool moving;
    public ScriptableBool_SO moving;

    float shootingTime = 0;

    private void FixedUpdate()
    {
        //text1.text = moving.ToString();

        if (moving.boolValue)
        {
            shootingTime += Time.fixedDeltaTime;

            if (shootingTime >= 0.5f)
            {
                moving.boolValue = false;
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
        moving.boolValue = true;
        shootingTime = 0;
    }

    void ShootRaysFixedUpdate()
    {
        var targetS = new Vector3(Screen.width / 2, Screen.height / 2);
        var r = new Ray(transform.position,transform.forward);

      

        RaycastHit info;
        Physics.Raycast(r,out info, 150, floorLayer,QueryTriggerInteraction.Collide);

        //text2.text = "hit " + Physics.Raycast(r, out info, 150, floorLayer, QueryTriggerInteraction.Collide);
      

        if (info.collider != null)
        {
            //Debug.Log("hit floor :)");
            //text3.text = info.collider.gameObject.name;
            floorManager.UpdateFloorSelected(info.collider.gameObject);
        }

    }

}
