using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Worker Manager List", menuName = "ElMasna3/Lists/Workers List")]
public class WorkerManagerList_SO : ScriptableObject {

	public List<Worker> Workers;

    public GameEvent_SO NewlyAddedEvent;

    public void Add(Worker w)
    {
        Workers.Add(w);
        NewlyAddedEvent.Raise();
    }

}
