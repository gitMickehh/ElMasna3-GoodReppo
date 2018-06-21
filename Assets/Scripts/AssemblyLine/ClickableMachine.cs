using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableMachine : MonoBehaviour
{
    //public Text fixMachineCost;
    public GameObject fixMachineConf_Panel;
    F_UI_MachineFixConf machineFixConf;
    public Machine machine;

    private void Start()
    {
        machineFixConf = fixMachineConf_Panel.GetComponent<F_UI_MachineFixConf>();
        machine = GetComponent<Machine>();
    }
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit hit;
                    Physics.Raycast(Camera.main.ScreenPointToRay(
                       (touch.position)), out hit);
                    //print("begin "+ hit.transform.name);
                    
                    if (hit.collider != null 
                        && hit.collider.CompareTag("Machine") 
                        && hit.transform.name == transform.name)
                    {
                        //print("Clicked on "+ hit.transform.name);
                        machineFixConf.SetFixCost(machine);
                        fixMachineConf_Panel.SetActive(true);
                    }
                    break;
            }
        }
    }

   
}
