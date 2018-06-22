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
    public GameObject police;

    public float onScreenTime = 2f;
    public float offScreenTime = 2f;
    public float happyTime = 2f;


    void Start ()
    {
        durationBetween2Spawns = 1f;
        gameStartEvent.Raise();
        StartCoroutine("CreateThieves");
        StartCoroutine("EnablePolice");
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

    public IEnumerator EnablePolice()
    {
        while (true)
        {
            police.SetActive(false);
            yield return new WaitForSeconds(offScreenTime);
            police.SetActive(true);
            yield return new WaitForSeconds(onScreenTime);
        }
    }
    public void PoliceIsHappyForAwhile()
    {
        StopCoroutine("EnablePolice");
        StartCoroutine("EnablingPoliceAfterHappyTime");

    }
    public IEnumerator EnablingPoliceAfterHappyTime()
    {
        yield return new WaitForSeconds(happyTime);
        StartCoroutine("EnablePolice");
    }
    public void DisablingTouchManager()
    {
        Debug.Log("Disable touch manager: Game Manager thief");
        touchManager.gameObject.SetActive(false);
    }

    public void FreezePolice()
    {
        print("Police Freezed");
        StopCoroutine("EnablePolice");
    }
	
}
