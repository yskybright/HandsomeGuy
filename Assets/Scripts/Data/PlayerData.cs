using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public string id;
    public float hp;
    public int maxHp;
    public float moveSpeed;
    public float damage;
    public float attackSpeed;
    public float damageReduceRatio;
    public int killCount;
    public float sightRange;
}
