using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    public GameEvent_SO swipeAway;
    Vector2 startPos;
    Vector2 endPos;
    Rigidbody2D rb;

    public Transform toDrag;
    float dist;
    bool dragging;
    Vector3 offset;

    private void Start()
    {
        dragging = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        float speed = Time.time;
        float moveHorizontal;
        float moveVertical;

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 v3;

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (dragging)
                    {

                        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                        v3 = Camera.main.ScreenToWorldPoint(v3);
                        toDrag.position = v3 + offset;

                    }
                    else
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(
                        (touch.position)), Vector2.zero);

                        if (hit.collider != null && hit.collider.CompareTag("Thief"))
                        {
                            Debug.Log("Soccer Ball clicked");
                            toDrag = hit.transform;

                            dist = hit.transform.position.z - Camera.main.transform.position.z;
                            v3 = new Vector3(touch.position.x, touch.position.y, dist);
                            v3 = Camera.main.ScreenToWorldPoint(v3);
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
                    startPos = touch.position;
                    endPos = touch.position;
                    moveHorizontal = 0.0f;
                    moveVertical = 0.0f;
                    break;


                case TouchPhase.Ended:
                    if (dragging)
                    {
                        swipeAway.Raise();
                        dragging = false;
                        
                        endPos = touch.position;
                        moveHorizontal = endPos.x - startPos.x;
                        moveVertical = endPos.y - startPos.y;
                        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

                        rb.velocity = (movement * speed) / 10;

                        StartCoroutine(GetComponent<Thief>().DestroyThief());
                    }

                    break;
            }
        }
    }

}
