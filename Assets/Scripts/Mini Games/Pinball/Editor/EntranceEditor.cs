using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PinballEntrance))]
public class EntranceEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PinballEntrance entrance = (PinballEntrance)target;

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (GUILayout.Button("Shoot 5 Balls") && Application.isPlaying)
        {
            entrance.ShootBalls(5);
        }

    }
}
