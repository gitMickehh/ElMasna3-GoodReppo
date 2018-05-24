using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Remove Player Prefs", menuName = "ElMasna3/Testing/PlayerPrefsRemover")]
public class PlayerPrefsRemover_SO : ScriptableObject {

	public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
    }
}
