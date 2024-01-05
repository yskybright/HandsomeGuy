using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickMissionController : MonoBehaviour
{
    public event Action<bool> missionEvent;

    public void CallMissionEvent(bool isSuccessMission)
    {
        missionEvent.Invoke(isSuccessMission);
    }
}
