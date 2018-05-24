using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class F_UI_ManagingButtons : MonoBehaviour {

    public CompanyMoneyUpdates_SO CompanyMoneyUpdates_SO;
    public Factory_SO Factory_SO;
    public Button levelUpButton;

    private void Start()
    {
        levelUpButton.interactable = false;
    }

    public void CheckToOpenLevelCompanyButton()
    {
        print("Factory_SO.FactoryMoney: " + Factory_SO.FactoryMoney + "CompanyMoneyUpdates_SO.levelUpCost: " + CompanyMoneyUpdates_SO.levelUpCost);
        if(Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.levelUpCost)
        {
            //openbutton
            print("Open levelup button.");
            if (levelUpButton.interactable == false)
                levelUpButton.interactable = true;
        }
        else
        {
            print("close levelup button.");
            if (levelUpButton.interactable == true)
                levelUpButton.interactable = false;
        }
    }

}
