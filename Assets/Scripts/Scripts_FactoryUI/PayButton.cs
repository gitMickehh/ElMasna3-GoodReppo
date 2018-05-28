using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PayButton : MonoBehaviour
{
    public CompanyMoneyUpdates_SO CompanyMoneyUpdates_SO;
    Text Text;

    private void Start()
    {
        Text = GetComponentInChildren<Text>();
    }
    public void SetText(int index)
    {
        switch (index)
        {
            case 0:
                Text.text = "Pay " + CompanyMoneyUpdates_SO.playForRedTeam;
                break;

            case 1:
                Text.text ="Pay " + CompanyMoneyUpdates_SO.playForYellowTeam;
                break;

            case 2:
                Text.text ="Pay " + CompanyMoneyUpdates_SO.playForGreenTeam;
                break;

                //case 3:
                //    Text.text = "Pay " + CompanyMoneyUpdates_SO.PlayForBlueTeam;
                //    break;
        }
    }
}
