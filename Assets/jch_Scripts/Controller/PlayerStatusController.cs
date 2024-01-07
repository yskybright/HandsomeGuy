using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    public event Action<bool> missionEvent;
    public event Action dieEvent;

    public void CallMissionEvent(bool isSuccessMission)
    {
        missionEvent?.Invoke(isSuccessMission);
    }

    public void CallDieEvent()
    {
        Revival hasRevival = Main.ObjectManager.Player.GetComponent<Revival>();
        if (hasRevival != null && hasRevival.RevivalCount != 0)
        {
            hasRevival.OnRevival();
            return;
        }

        dieEvent?.Invoke();
    }
}
