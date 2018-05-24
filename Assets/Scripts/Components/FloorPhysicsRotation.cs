using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorPhysicsRotation : MonoBehaviour
{

    public float SwipeSpeed;
    float coeff = 1;
    Rigidbody rb;

    bool isSwiping;
    Vector2 origPos;
    Vector3 Torque;
    float newY;
    //public Text debug;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (Input.touchCount == 1)
        {
            //debug.text = "Swiping";
            Touch touchZero = Input.GetTouch(0);
            switch (touchZero.phase)
            {
                case TouchPhase.Began:
                    origPos = touchZero.position;
                    //debug.text = origPos.ToString();
                    break;
                case TouchPhase.Moved:
                    float deltaMagnitudeDiff = origPos.x - touchZero.position.x;

                    //debug.text = deltaMagnitudeDiff.ToString();

                    if (Mathf.Abs(deltaMagnitudeDiff) >= 5)
                    {
                        //debug.text = "Torque";
                        isSwiping = true;
                        SwipeSpeed = -touchZero.deltaPosition.x / touchZero.deltaTime;
                        Torque = new Vector3(0,SwipeSpeed * coeff, 0);
                    }

                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
                default:
                    isSwiping = false;
                    break;
            }



        }

    }

    void FixedUpdate()
    {
        if (isSwiping)
        {
            rb.AddRelativeTorque(Torque);
            //debug.text = Torque.ToString();
        }
    }

}
