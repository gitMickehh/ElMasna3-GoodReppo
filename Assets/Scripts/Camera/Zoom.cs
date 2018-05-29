using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    public Transform zoomTargetPos;
    public float transitionDuration = 10f;
    public Transform lastTransform;
    public bool zoomed;

    private void Start()
    {
        zoomed = false;
    }

    public IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        lastTransform = transform;
       while (t < 1.0f)
        {
          t += Time.deltaTime * (Time.timeScale / transitionDuration);
          //  print("Time.timeScale: " + Time.timeScale);
          //  t += Time.deltaTime * (0.1f);


            transform.position = Vector3.Lerp(startingPos, zoomTargetPos.position, t);
            //transform.rotation = Quaternion.Lerp(startingTransform.rotation, zoomTargetPos.rotation, t);
            transform.localRotation = Quaternion.RotateTowards(lastTransform.localRotation, zoomTargetPos.rotation, t);
            zoomed = true;
            yield return 0;
        }

    }

}