using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Events List", menuName = "ElMasna3/Lists/Random Events List")]
public class RandomEventsList_SO : ScriptableObject {

    [SerializeField]
    List<GameEvent_SO> listOfEvents;

    [SerializeField]
    [Tooltip("Anything")]
    List<int> EventsWeights;

    URandom.ShuffleBagCollection<int> shufflebag;

    private void OnEnable()
    {
        shufflebag = new URandom.ShuffleBagCollection<int>();

        for (int i = 0; i < listOfEvents.Count; i++)
        {
            shufflebag.Add(i,EventsWeights[i]);
        }
    }

    public GameEvent_SO PickRandomEvent()
    {
        int r = Random.Range(0, listOfEvents.Count);

        return listOfEvents[r];
    }

    public GameEvent_SO PickRandomEventWithWeights()
    {
        //apply weights here...
        //biggest weight returns null
        //int r = Random.Range(0, listOfEvents.Count);

        int r = shufflebag.Next();

        return listOfEvents[shufflebag.Next()];
    }

}
