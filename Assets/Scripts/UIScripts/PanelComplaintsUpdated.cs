using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComplaintsUpdated : MonoBehaviour
{

    public ListWithEvent_SO runtimeComplaints;
    public Transform panelComplaintsHolder;
    public GameObject complaintsHolderPrefab;

    public Button[] buttons;

    private void Start()
    {
        buttons = panelComplaintsHolder.GetComponentsInChildren<Button>();

        UpdatePanel();

    }


    public void UpdatePanel()
    {
        buttons = panelComplaintsHolder.GetComponentsInChildren<Button>();

        int j = 0;
        for (int i = 0; i < runtimeComplaints.listElements.Count; i++)
        {
            if (j < buttons.Length)
            {
                buttons[j].GetComponentInChildren<Text>().text = ((Complaints_SO)(runtimeComplaints.listElements[i])).Complaint;
                j += 2;

                //Debug.Log(((Complaints_SO)(runtimeComplaints.listElements[i])).Complaint);
            }

            else
            {
                GameObject newComplaint = Instantiate(complaintsHolderPrefab, panelComplaintsHolder);
                newComplaint.GetComponentInChildren<Text>().text = ((Complaints_SO)(runtimeComplaints.listElements[i])).Complaint;
                //Debug.Log("out");

            }

        }


        for (; j < buttons.Length; j += 2)
        {
            print("Destroy");
            Destroy(buttons[j].gameObject);
        }


    }
}
