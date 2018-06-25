using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekMoney : SteeringBase
{

    public float PositionTargetTolerance = 0.5f;
    public Vector3? Target;
    int no;
    bool runningAway;
    public GameEvent_SO moneyLostEvent;
    public GameEvent_SO timeIsUpEvent;
    public GameObject setOfMoney;


    private void Start()
    {
        setOfMoney = GetComponentInParent<Thieves>().setOfMoney;
        
        
            Target = setOfMoney.GetComponent<SetOfMoney>().GetNextTarget();
        if (Target == null)
        {
            //print("Something Wrong");
            DestroyImmediate(gameObject);
        }
        else
        {
            no = SetOfMoney.indexOfTarget;
        }
        

    }

    private void FixedUpdate()
    {
        var distanceFromTarget = Vector3.Distance(Position, Target.Value);

        if (distanceFromTarget > PositionTargetTolerance)
        {
            Steering += Seek();

            UpdateMovement();
        }
        else
        {
            //thief escaped 
            if (transform.childCount > 0)
            {
                MoneyStole();
            }
            else
            {
                //print("Didn't have a target");
                DestroyImmediate(gameObject);
            }
        }

    }

    Vector3 Seek()
    {
        var desiredVelocity = (Target.Value - Position).normalized * MaxSteering;

        var TargetForce = desiredVelocity - Velocity;

        TargetForce = ClampVector3(TargetForce, MaxSteering);
        var SeekSteering = TargetForce / Mass;

        return SeekSteering;
    }

    public void RunAway()
    {
        Target = GetComponent<Thief>().startPlace;

    }

    public void MoneyStole()
    {
        if (transform.childCount > 0)
        {
            //print("Money is lost");
            moneyLostEvent.Raise();
            DestroyImmediate(gameObject);

            //check if there was no money left
            //CheckForMoneyLeft();
        }
    }
    
    //public void CheckForMoneyLeft()
    //{
    //    if (setOfMoney.transform.childCount == 0)
    //    {
    //        timeIsUpEvent.Raise();
    //    }
    //}
}
