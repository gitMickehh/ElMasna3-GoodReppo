using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reference Bool", menuName = "ElMasna3/Variables/Boolean")]
public class ScriptableBool_SO : ScriptableObject {

    public bool boolValue;

    public void SetValue(bool val)
    {
        boolValue = val;
    }

}
