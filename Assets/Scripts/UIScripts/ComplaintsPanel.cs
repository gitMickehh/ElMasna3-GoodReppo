using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplaintsPanel : MonoBehaviour {


    public void ClickedOnButtonComplaints(Animator anim)
    {
        if (anim.GetBool("ButtonClicked"))
        {
            anim.SetBool("ButtonClicked", false);

            GetComponent<UI_OpenCloseEvent>().UI_CloseEvent.Raise();
        }
        else
        {
            anim.SetBool("ButtonClicked", true);

            GetComponent<UI_OpenCloseEvent>().UI_OpenEvent.Raise();
        }
    }
}
