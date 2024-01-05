using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class BaseSkill : MonoBehaviour
{
    protected PlayerData player;
    protected Data.Skill skill;
    private void Start()
    {
        Init();
    }


    protected virtual void Init()
    {
        player = Main.ObjectManager.Player;

        Debug.Log(player.attackSpeed);
        Debug.Log(player.damage);
        Debug.Log(player.damageReduceRatio);
        Debug.Log(player.hp);
        Debug.Log(player.maxHp);
        Debug.Log(player.killCount);
    }
}
