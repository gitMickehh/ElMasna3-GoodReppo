using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTxt : MonoBehaviour {

    public Text text;

    public void SetText(int index)
    {
        switch (index)
        {
            case 0:
                text.text = "Increase red team level";
                break;

            case 1:
                text.text = "Increase yellow team level";
                break;

            case 2:
                text.text = "Increase purple team level";
                break;

            default:
                print("No team at this index.");
                break;
        }
    }
	
}
