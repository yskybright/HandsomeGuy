using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reducer : MonoBehaviour
{
    //Tester들입니다
    public void Reduceds()
    {
        Main.ObjectManager.Player._currentHp -= (10 - Mathf.RoundToInt(10 * Main.ObjectManager.Player._damageReduceRatio / 100));
    }

    public void IncreKillCount()
    {
        Main.ObjectManager.Player._killCount++;
    }

    public void MissionSuccess()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerStatusController controller = player.GetComponent<PlayerStatusController>();
        controller.CallMissionEvent(true);
    }

    public void Die()
    {
        Main.ObjectManager.Player._currentHp = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        PlayerStatusController controller = player.GetComponent<PlayerStatusController>();
        controller.CallDieEvent();
    }

    public void OnInvisible()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<BaseActive>().UseSkill(); ;
    }
}
