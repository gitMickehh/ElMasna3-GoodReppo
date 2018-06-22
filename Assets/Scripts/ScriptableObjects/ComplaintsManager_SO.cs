using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComplaintsManager", menuName = "ElMasna3/ComplaintsManager")]
public class ComplaintsManager_SO : ScriptableObject
{

    //public List_SO complaints;
    public List_SO workerComplaints;

    public Complaints_SO GenerateRandomWorkerComplaint()
    {
        int no = Random.Range(0, workerComplaints.ListElements.Count);

        return (Complaints_SO)(workerComplaints.ListElements)[no];
    }


}
