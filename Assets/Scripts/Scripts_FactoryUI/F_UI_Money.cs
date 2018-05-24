using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class F_UI_Money : MonoBehaviour {

    public Text companyMoney;
    public Factory_SO factory_SO;

    void Start()
    {
        companyMoney.text = factory_SO.FactoryMoney.ToString();
    }

    public void ChangeFactoryMoney()
    {
        companyMoney.text = factory_SO.FactoryMoney.ToString();
    }
}
