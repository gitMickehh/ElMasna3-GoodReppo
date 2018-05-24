using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerPrefsRemover_SO))]
public class PlayerPrefsRemover_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerPrefsRemover_SO ppRemover = (PlayerPrefsRemover_SO)target;

        if (GUILayout.Button("Delete Player Prefs"))
        {
            ppRemover.DeletePlayerPrefs();
        }

    }
}
