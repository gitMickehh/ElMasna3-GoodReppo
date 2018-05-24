using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Evented List", menuName = "ElMasna3/Lists/List With Event")]
public class ListWithEvent_SO : ScriptableObject {

    //[SerializeField]
    public List<ScriptableObject> listElements;

    public GameEvent_SO elementUpdate;

    
    public void AddElement(ScriptableObject objectAdded)
    {
        listElements.Add(objectAdded);
        elementUpdate.Raise();
    }

    public void RemoveElement(ScriptableObject objectRemoved)
    {
        listElements.Remove(objectRemoved);
        elementUpdate.Raise();
    }
}
