using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    public event Action missionEvent;
    public event Action dieEvent;

    public void CallMissionEvent()
    {
        Debug.Log("사람 열림");
        missionEvent?.Invoke();
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
    private void OnEnable()
    {
        Main.GameManager.RepairCompleteEvent += CallMissionEvent;
    }
}
