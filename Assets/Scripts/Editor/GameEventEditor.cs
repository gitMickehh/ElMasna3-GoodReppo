using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent_SO))]
public class GameEventEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameEvent_SO gameEvent = (GameEvent_SO)target;

        if(GUILayout.Button("Fire"))
        {
            gameEvent.Raise();
        }

    }

}
