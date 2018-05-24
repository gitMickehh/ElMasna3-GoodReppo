using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String List", menuName = "ElMasna3/Lists/String List")]
public class ListOfStrings_SO : ScriptableObject {

    public List<string> strings;


    public void ClearList()
    {
        strings.Clear();
    }

}
