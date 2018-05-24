using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplaintsUI_Script : MonoBehaviour {

    Animator anim;
    public Image ComplaintsBoard;

    public GameObject ComplaintHolder;

    public List_SO ComplaintsList; 

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        
        //test
        //Instantiate(ComplaintHolder, ComplaintsBoard.transform);
        //Instantiate(ComplaintHolder, ComplaintsBoard.transform);
        //Instantiate(ComplaintHolder, ComplaintsBoard.transform);
    }

    public void ComplainsON()
    {
        anim.SetBool("In", true);
    }

    public void ComplainsOFF()
    {
        anim.SetBool("In", false);
    }
}
