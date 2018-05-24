using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Camera Navigation", menuName = "ElMasna3/Camera Navigation")]
public class CameraNavigation_SO : ScriptableObject {


    public float MinimumYPosition = 10f;
    public float MaximumYPosition = 17.5f;


    private void OnEnable()
    {
        MaximumYPosition = 17.5f;
    }
}
