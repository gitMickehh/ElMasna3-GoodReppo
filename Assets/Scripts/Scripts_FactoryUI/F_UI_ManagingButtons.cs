using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class F_UI_ManagingButtons : MonoBehaviour {

    public CompanyMoneyUpdates_SO CompanyMoneyUpdates_SO;
    public Factory_SO Factory_SO;

    public WorkerManager WorkerManager;

    public Button levelUpButton;

    public Button levelUpRedButton;
    public Button levelUpYellowButton;
    public Button levelUpGreenButton;
    // public Button levelUpBlueButton;



    private void Start()
    {
        //levelUpButton.interactable = false;

        //levelUpRedButton.interactable = false;
        //levelUpYellowButton.interactable = false;
        //levelUpGreenButton.interactable = false;


        CheckToOpenLevelCompanyButton();

        CheckToOpenLevelTeamButton();
        
    }

    public void CheckToOpenLevelCompanyButton()
    {
        //print("WorkerManager.WorkersPrefabs.Count: " + WorkerManager.WorkersPrefabs.Count);
        //print("Factory_SO.FactoryMoney: " + Factory_SO.FactoryMoney + "CompanyMoneyUpdates_SO.levelUpCost: " + CompanyMoneyUpdates_SO.LevelUpCost);
        if((Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.LevelUpCost) && 
            (WorkerManager.WorkersPrefabs.Count >= (Factory_SO.companyLevel * 10)))//no of workers is missing as condition
        {
            //openbutton
            //print("Open levelup button.");
            if (levelUpButton.interactable == false)
                levelUpButton.interactable = true;
        }
        else
        {
            
            //print("close levelup button.");
            //print("Factory_SO.FactoryMoney: "+ Factory_SO.FactoryMoney + " CompanyMoneyUpdates_SO.LevelUpCost: "+ CompanyMoneyUpdates_SO.LevelUpCost);
            //print("WorkerManager.WorkersPrefabs.Count: "+ WorkerManager.WorkersPrefabs.Count +  " Factory_SO.companyLevel * 10): "+ (Factory_SO.companyLevel * 10));
            if (levelUpButton.interactable == true)
                levelUpButton.interactable = false;
        }
    }

    public void CheckToOpenLevelTeamButton()
    {
        CheckToOpenLevelRedTeamButton();
        CheckToOpenLevelYellowTeamButton();
        CheckToOpenLevelGreenTeamButton();
        //CheckToOpenLevelBlueTeamButton();
    }
    public void CheckToOpenLevelRedTeamButton()
    {
        if ((Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.playForRedTeam) && WorkerManager.RedColorOverSix > 0)
        {
            if (levelUpRedButton.interactable == false)
                levelUpRedButton.interactable = true;
        }
        else
        {
            if (levelUpRedButton.interactable == true)
                levelUpRedButton.interactable = false;
        }
    }

    public void CheckToOpenLevelYellowTeamButton()
    {
        if ((Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.playForYellowTeam) && WorkerManager.YellowColorOverSix > 0)
        {
            if (levelUpYellowButton.interactable == false)
                levelUpYellowButton.interactable = true;
        }
        else
        {
            if (levelUpYellowButton.interactable == true)
                levelUpYellowButton.interactable = false;
        }
    }

    public void CheckToOpenLevelGreenTeamButton()
    {
        if ((Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.playForGreenTeam) && WorkerManager.GreenColorOverSix > 0)
        {
            if (levelUpGreenButton.interactable == false)
                levelUpGreenButton.interactable = true;
        }
        else
        {
            if (levelUpGreenButton.interactable == true)
                levelUpGreenButton.interactable = false;
        }
    }
/*
    public void CheckToOpenLevelBlueTeamButton()
    {
        if ((Factory_SO.FactoryMoney >= CompanyMoneyUpdates_SO.playForBlueTeam) && WorkerManager.BlueColorOverSix > 0)
        {
            if (levelUpBlueButton.interactable == false)
                levelUpBlueButton.interactable = true;
        }
        else
        {
            if (levelUpBlueButton.interactable == true)
                levelUpBlueButton.interactable = false;
        }
    }
    */
}
