using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    Camera thiefCam;

    public GameEvent_SO swipeAway;
    Vector2 startPos;
    Vector2 endPos;
    //Rigidbody2D rb;

    public Transform toDrag;
    //public float speed;
    float dist;
    bool dragging;
    bool oneTap;
    Vector3 offset;
    public SetOfMoney setOfMoney;

    private void Awake()
    {
        setOfMoney = FindObjectOfType<SetOfMoney>();
    }
    private void Start()
    {
        dragging = false;
        oneTap = false;
        
        thiefCam = GameObject.FindGameObjectWithTag("ThiefCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        float speed = 10;
        float moveHorizontal;
        float moveVertical;

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 v3;

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    RaycastHit2D hit = Physics2D.Raycast(thiefCam.ScreenToWorldPoint(
                        (touch.position)), Vector2.zero);

                    if (hit.collider != null && hit.collider.CompareTag("Thief"))
                    {
                        print("Touch Theif");
                        toDrag = hit.transform;

                        dist = toDrag.position.z - thiefCam.transform.position.z;
                        v3 = new Vector3(touch.position.x, touch.position.y, dist);
                        v3 = thiefCam.ScreenToWorldPoint(v3);
                        offset = toDrag.position - v3;

                        startPos = touch.position;
                        endPos = touch.position;
                        moveHorizontal = 0.0f;
                        moveVertical = 0.0f;
                        oneTap = true;
                        dragging = true;
                    }

                    break;

                case TouchPhase.Moved:
                    if (dragging)
                    {
                        oneTap = false;
                        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                        v3 = thiefCam.ScreenToWorldPoint(v3);
                        toDrag.position = v3 + offset;
                        toDrag.GetComponent<Thief>().swiped = true;
                        toDrag.GetComponent<LeaveMoney>().LeaveMoneyWhenRunning();

                    }
                    else
                    {
                        oneTap = false;
                        RaycastHit2D hit1 = Physics2D.Raycast(thiefCam.ScreenToWorldPoint(
                        (touch.position)), Vector2.zero);
                       
                        if (hit1.collider != null && hit1.collider.CompareTag("Thief"))
                        {
                            print("Touch Theif");
                            toDrag = hit1.transform;

                            dist = toDrag.position.z - thiefCam.transform.position.z;
                            v3 = new Vector3(touch.position.x, touch.position.y, dist);
                            v3 = thiefCam.ScreenToWorldPoint(v3);
                            offset = toDrag.position - v3;

                            startPos = touch.position;
                            endPos = touch.position;
                            moveHorizontal = 0.0f;
                            moveVertical = 0.0f;
                            dragging = true;
                        }
                    }
                    break;

                case TouchPhase.Stationary:
                    endPos = touch.position;
                    moveHorizontal = 0.0f;
                    moveVertical = 0.0f;
                    break;


                case TouchPhase.Ended:
                    if (dragging && !oneTap)
                    {
                        dragging = false;

                        endPos = touch.position;
                        toDrag.GetComponent<SeekMoney>().enabled = false;


                        moveHorizontal = endPos.x - startPos.x;
                        moveVertical = endPos.y - startPos.y;
                        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
                        movement.Normalize();

                        toDrag.GetComponent<Rigidbody2D>().velocity = (movement * speed);
                        Destroy(toDrag.gameObject, 2);

                        FindObjectOfType<AudioManager>().Play("Swoosh1");
                    }

                    break;
            }
        }
    }

   
    public void SetDraggingFalse()
    {
        dragging = false;
        toDrag.tag = "Untagged";
        toDrag = null;
    }

}
