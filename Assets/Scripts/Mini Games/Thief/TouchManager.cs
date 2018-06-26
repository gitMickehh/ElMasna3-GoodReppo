using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    Camera thiefCam;

    //public GameEvent_SO swipeAway;
    Vector2 startPos;
    Vector2 endPos;

    public Transform toDrag;
    float dist;
    Vector3 offset;
    Vector3 v3;
    public SetOfMoney setOfMoney;
    public Explosion explosion;

    bool firstPlay;
    bool dragging;

    //were in update - put here to avoid garbage collector
    float speed = 10;
    float moveHorizontal;
    float moveVertical;

    private void Awake()
    {
        setOfMoney = FindObjectOfType<SetOfMoney>();
        explosion = FindObjectOfType<Explosion>();
        thiefCam = GameObject.FindGameObjectWithTag("ThiefCamera").GetComponent<Camera>();
    }
    private void Start()
    {
        dragging = false;
        firstPlay = true;
    }

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            // Vector3 v3;

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    ThrowRay(touch);


                    break;

                case TouchPhase.Moved:
                    if (dragging)
                    {
                        if (firstPlay)
                        {
                            PlayExplosion();
                            firstPlay = false;
                        }

                        //print("moving " + toDrag.name);
                        1
                        DragThief(touch);

                        toDrag.GetComponent<Thief>().swiped = true;
                        toDrag.GetComponent<LeaveMoney>().LeaveMoneyWhenRunning();

                    }
                    else
                    {
                        ThrowRay(touch);
                    }
                    break;

                case TouchPhase.Stationary:
                    endPos = touch.position;
                    moveHorizontal = 0.0f;
                    moveVertical = 0.0f;
                    break;


                case TouchPhase.Ended:
                    if (dragging && toDrag.GetComponent<Thief>().swiped) // !oneTap)
                    {
                        //print("leave " + toDrag.name);
                        
                        
                        dragging = false;

                        endPos = touch.position;
                        toDrag.GetComponent<SeekMoney>().enabled = false;

                        toDrag.GetComponent<Rigidbody2D>().velocity = GetDraggingVelocity();
                        Destroy(toDrag.gameObject, 2);

                        FindObjectOfType<AudioManager>().Play("Swoosh1");
                    }
                    else
                    {
                        dragging = false;
                    }

                    break;
            }
        }
    }

    void DragThief(Touch touch)
    {
        v3 = new Vector3(touch.position.x, touch.position.y, toDrag.position.z);
        //v3 = new Vector3(touch.position.x, touch.position.y, dist);

        v3 = thiefCam.ScreenToWorldPoint(v3);
        toDrag.position = v3 + offset;
    }

    Vector3 GetDraggingVelocity()
    {
        moveHorizontal = endPos.x - startPos.x;
        moveVertical = endPos.y - startPos.y;
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        movement.Normalize();

        return (movement * speed);
    }

    public void ThrowRay(Touch touch)
    {
        RaycastHit2D hit = Physics2D.Raycast(thiefCam.ScreenToWorldPoint(
                        (touch.position)), Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Thief") && !hit.transform.gameObject.GetComponent<Thief>().swiped)
        {

            toDrag = hit.transform;
            //print("begin Touch " + toDrag.name);

            dist = toDrag.position.z - thiefCam.transform.position.z;
            //v3 = new Vector3(touch.position.x, touch.position.y, dist);
            v3 = new Vector3(touch.position.x, touch.position.y, toDrag.position.z);
            v3 = thiefCam.ScreenToWorldPoint(v3);
            offset = toDrag.position - v3;

            startPos = touch.position;
            endPos = touch.position;
            moveHorizontal = 0.0f;
            moveVertical = 0.0f;
            dragging = true;
            firstPlay = true;
        }
    }


    public void PlayExplosion()
    {
        explosion.SetExplosionPos(toDrag);
        explosion.ExplosionEffect();
        
    }

    public void SetDraggingFalse()
    {
        dragging = false;
        toDrag.tag = "Untagged";
        //toDrag = null;
    }

}
