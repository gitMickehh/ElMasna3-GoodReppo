using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public Vector3 startingPoint;

	// Use this for initialization
	void Start () {
        startingPoint = transform.position;
    }

    public void ResetMoney()
    {
        transform.position = startingPoint;
    }

}
