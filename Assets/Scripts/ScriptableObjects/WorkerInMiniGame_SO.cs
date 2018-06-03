using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkerInMiniGame_SO", menuName = "ElMasna3/Worker/WorkerInMiniGame_SO")]
public class WorkerInMiniGame_SO : ScriptableObject {

    [SerializeField]
    Worker workerInGame;
    public bool workerWon;

    public Worker WorkerInGame
    {
        get
        {
            return workerInGame;
        }
        set
        {
            workerInGame = value;
        }
    }
}
