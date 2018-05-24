using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class F_UI_LevelUp : MonoBehaviour {

    public Text factoryLevelNo;
    public Factory_SO factory_SO;

	void Start () {
        factoryLevelNo.text = factory_SO.companyLevel.ToString();
    }

    public void LevelUpFactory()
    {
        factoryLevelNo.text = factory_SO.companyLevel.ToString();
    }
}
