using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBase : MonoBehaviour
{
    public float MaxVelocity;
    public float MaxSteering;
    public Vector3 Position { set { transform.position = value; } get { return transform.position; } }
    [HideInInspector]
    public  Vector3 Velocity;
    [HideInInspector]
    public Vector3 Steering;
    public float Mass;
    
    protected void UpdateMovement()
    {
        Steering = ClampVector3(Steering, MaxSteering);
        Velocity = Velocity + Steering * Time.fixedDeltaTime;

        Velocity = ClampVector3(Velocity, MaxVelocity);
        Position = Position + Velocity * Time.fixedDeltaTime;
    }

    protected Vector3 ClampVector3(Vector3 target, float maxMagnitude)
    {
        if (target.magnitude > maxMagnitude)
            target = target.normalized * maxMagnitude;
        return target;
    }
}
