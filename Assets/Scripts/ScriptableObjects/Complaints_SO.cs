using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "New Complaint", menuName = "ElMasna3/Complaint")]
    public class Complaints_SO : ScriptableObject
    {

        [TextArea]
        public string Complaint;

    }
