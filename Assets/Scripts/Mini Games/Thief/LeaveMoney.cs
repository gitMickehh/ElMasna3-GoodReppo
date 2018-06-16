using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveMoney : MonoBehaviour {

    public GameObject setOfMoney;
    public GameManager gameManager;

    private void Start()
    {
        setOfMoney = GetComponentInParent<Thieves>().setOfMoney;
    }
    public void LeaveMoneyWhenRunning()
    {
        //GetComponent<BoxCollider2D>().enabled = false;
        if (transform.childCount > 0)
        {
            print("LeaveMoney");
            
            transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(0).gameObject.transform.SetParent(setOfMoney.transform);


        }
    }
}
