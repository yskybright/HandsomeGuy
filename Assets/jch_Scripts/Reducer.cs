using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reducer : MonoBehaviour
{
    public void Reduceds()
    {
        Main.ObjectManager.Player.hp -= (10 - Mathf.RoundToInt(10 * Main.ObjectManager.Player.damageReduceRatio / 100));
    }

    public void IncreKillCount()
    {
        Main.ObjectManager.Player.killCount++;
    }

    public void MissionSuccess()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        GimmickMissionController controller = player.GetComponent<GimmickMissionController>();
        controller.CallMissionEvent(true);
    }
}
