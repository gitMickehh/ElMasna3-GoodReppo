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

        slideNumber = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow))
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
            director.playableAsset = timeLinesInOrder[slideNumber];
            slideNumber++;
        }

        director.Play();
    }

    void PrevSlide()
    {
        slideNumber--;
        director.playableAsset = timeLinesInOrder[slideNumber];

        prevPresed = true;
    }

}
