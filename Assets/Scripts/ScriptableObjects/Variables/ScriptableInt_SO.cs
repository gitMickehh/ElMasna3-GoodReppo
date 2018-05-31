using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reference Int", menuName = "ElMasna3/Variables/Int")]
public class ScriptableInt_SO : ScriptableObject {

    public int intValue;

    private void OnEnable()
    {
        intValue = 0;
    }

    public void SetValue(int val)
    {
        intValue = val;
    }
}
