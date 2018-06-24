using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

    public Image []Images;
    public Button prevBtn;
    public Button nextBtn;

    int index;

    private void OnEnable()
    {
        Images[0].gameObject.SetActive(true);
        index = 0;
        prevBtn.interactable = false;
    }
    public void PlayPrevious()
    {
        Images[index].gameObject.SetActive(false);
        index--;
        Images[index].gameObject.SetActive(true);
        if(index == 0)
        {
            prevBtn.interactable = false;
        }

        if (nextBtn.interactable == false)
            nextBtn.interactable = true;

    }

    public void PlayNext()
    {
        Images[index].gameObject.SetActive(false);
        index++;
        Images[index].gameObject.SetActive(true);

        if (index == Images.Length - 1)
        {
            nextBtn.interactable = false;
        }

        if (prevBtn.interactable == false)
            prevBtn.interactable = true;
    }

}
