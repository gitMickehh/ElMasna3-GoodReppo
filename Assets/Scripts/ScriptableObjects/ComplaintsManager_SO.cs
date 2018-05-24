using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComplaintsManager", menuName = "ElMasna3/ComplaintsManager")]
public class ComplaintsManager_SO : ScriptableObject
{

    public List_SO complaints;

    public Complaints_SO GenerateRandomComplaint()
    {
        int no = Random.Range(0, complaints.ListElements.Count);

        return (Complaints_SO)(complaints.ListElements)[no];
    }


}
