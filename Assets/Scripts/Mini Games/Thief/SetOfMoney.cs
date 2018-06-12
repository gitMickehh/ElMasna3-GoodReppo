using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfMoney : MonoBehaviour
{
   
    public static int indexOfTarget;
    public GameObject setOfMoney;
    public static int moneyValue;

    public void OnStart()
    {
        setOfMoney = gameObject;
        indexOfTarget = transform.childCount;
        moneyValue = 100;
    }

    public Vector3? GetNextTarget()
    {

        indexOfTarget--;
        if ((indexOfTarget < 0) && (transform.childCount > 0))
        {
            indexOfTarget = transform.childCount -1;
        }
        else if((indexOfTarget < 0) && (transform.childCount == 0))
        {
            return null;
        }
           
        return transform.GetChild(indexOfTarget).position;

    }
}
