using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
    Fading fading;

    private void Start()
    {
        fading = GetComponentInParent<Fading>();
    }

    public void OnPlayButtonClicked()
    {
        //SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        float fadeTime = fading.BeginFade(1);
        StartCoroutine(Wait(fadeTime));
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
