using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_LevelUp : MonoBehaviour {

    private void Start()
    {
        //LevelUpFactory();
        levelNo.text = (factory_SO.companyLevel).ToString();

    }

    public Factory_SO factory_SO;
    public Text levelNo;

    public void LevelUpFactory()
    {
        factory_SO.companyLevel++;
        levelNo.text = (factory_SO.companyLevel).ToString();
    }
}
