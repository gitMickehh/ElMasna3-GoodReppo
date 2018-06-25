using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DirectorCode : MonoBehaviour {


    public TimelineAsset[] timeLinesInOrder;
    private PlayableDirector director;
    private int slideNumber;
    bool prevPresed = false;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.playableAsset = null;

        slideNumber = -1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("next");
            NextSlide();
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PrevSlide();
            Debug.Log("Prev");
        }
    }

    void NextSlide()
    {
        if(!prevPresed)
        {
            if (slideNumber < timeLinesInOrder.Length-1)
            {
                slideNumber++;
            }
            else
            {
                slideNumber = timeLinesInOrder.Length - 1;
            }

            director.playableAsset = timeLinesInOrder[slideNumber];

        }

        director.Play();
    }

    void PrevSlide()
    {

        if (slideNumber < 0)
        {
            slideNumber = 0;
        }
        else
        {
            slideNumber--;
        }

        director.playableAsset = timeLinesInOrder[slideNumber];
        prevPresed = true;
    }

}
