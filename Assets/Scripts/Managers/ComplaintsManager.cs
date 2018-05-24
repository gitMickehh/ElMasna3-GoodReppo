using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplaintsManager : MonoBehaviour {

    //list that has all the complaints
    public List_SO allComplaints;
    public ListWithEvent_SO complaintsRuntimeList;

    public void DayOff()
    {
        complaintsRuntimeList.RemoveElement(allComplaints.ListElements[0]);
    }

    public void FixMachine()
    {
        complaintsRuntimeList.RemoveElement(allComplaints.ListElements[1]);
    }

    public void GivenPromotion()
    {
        complaintsRuntimeList.RemoveElement(allComplaints.ListElements[2]);
    }

    public void LevelUpSlowWorker()
    {
        complaintsRuntimeList.RemoveElement(allComplaints.ListElements[3]);
    }
}
