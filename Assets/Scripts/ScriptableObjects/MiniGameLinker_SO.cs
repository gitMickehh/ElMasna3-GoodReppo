using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Color Link", menuName ="ElMasna3/Color Linker")]
public class MiniGameLinker_SO : ScriptableObject {

    [Header("Color")]
    public string colorName;
    public Color ShirtColor;

    public string MiniGameName;

    [TextArea]
    public string Description;

    [Header("Scene")]
    //to have the link to the mini games
    public string sceneRef = "AddRefereceToMiniGameSceneHere";
    public int sceneBuildIndex;
    public string sceneName;
}
