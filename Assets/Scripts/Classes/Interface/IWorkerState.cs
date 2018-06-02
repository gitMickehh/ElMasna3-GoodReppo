using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkerState {

    void OnEnterState();
    void OnUpdateState();
    void OnExitState();
}
