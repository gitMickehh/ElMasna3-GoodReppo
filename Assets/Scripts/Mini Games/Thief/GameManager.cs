using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject [] thiefPrefab;
    public float durationBetween2Spawns;
    public Transform[] thiefStartPlaces;
    public Transform thieves;
    public GameEvent_SO gameStartEvent;
    public TouchManager touchManager;


    void Start ()
    {
        durationBetween2Spawns = 4f;
        gameStartEvent.Raise();
        StartCoroutine("CreateThieves");
    }

    public IEnumerator CreateThieves()
    {
        while (true)
        {
            int no = Random.Range(0, thiefStartPlaces.Length);
            int no1 = Random.Range(0, thiefPrefab.Length);
            GameObject w = Instantiate(thiefPrefab[no1], thiefStartPlaces[no]);
            w.transform.SetParent(thieves);
            yield return new WaitForSeconds(durationBetween2Spawns);
        }


    }

    public void StopSpawning()
    {
        StopCoroutine("CreateThieves");
    }

    public void DisablingTouchManager()
    {
        touchManager.gameObject.SetActive(false);
    }
	
}
