using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_UI_MachineFixConf : MonoBehaviour {
    
    public Text text;
    public Text addReduceMoney;
    public Button pay_Btn;
    public Factory_SO factory_SO;
    public Animator reduceAnim;
    public float fixingCost;
    Machine brokenMachine;

    public void Start()
    {
        reduceAnim = addReduceMoney.GetComponent<Animator>();
    }
    public void SetFixCost(Machine machine)
    {
        brokenMachine = machine;
        fixingCost = brokenMachine.FixingCost;
        text.text = "Fix machine to return Line to working state __ Pay " + fixingCost.ToString();
    }
    
    public void OnClick()
    {
        if (factory_SO.CheckMoneyAvailability(fixingCost))
        {
            addReduceMoney.gameObject.SetActive(true);
            factory_SO.WithdrawMoney(fixingCost);      
            addReduceMoney.text = "- " + fixingCost;
            reduceAnim.SetTrigger("Reduce");
            //while (reduceAnim.GetCurrentAnimatorStateInfo(0).IsName("ReduceMoneyAnim"))
            //{
            //    print("in ReduceMoneyAnim");
            //}

            //addReduceMoney.gameObject.SetActive(false);
            brokenMachine.MachineFixed();
        }

        else
        {
            //print in ui text in no enough money
        }
    }

}
