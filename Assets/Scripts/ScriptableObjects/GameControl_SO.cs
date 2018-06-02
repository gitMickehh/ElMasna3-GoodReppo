using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Control Set", menuName = "ElMasna3/Factory/Game Control Set")]
public class GameControl_SO : ScriptableObject {

    public List<GameEvent_SO> generalEvents;
    public List<GameEvent_SO> factoryEvents;
    public List<GameEvent_SO> thiefEvents;

    public void ClearFactoryEvents()
    {
        for (int i = 0; i < factoryEvents.Count; i++)
        {
            factoryEvents[i].ClearListeners();
        }
    }

    public void ClearThiefEvents()
    {
        for (int i = 0; i < thiefEvents.Count; i++)
        {
            thiefEvents[i].ClearListeners();
        }
    }

}
