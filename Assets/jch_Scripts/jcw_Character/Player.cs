using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int maxhp = 100;
    public float speed = 1.0f;
    public int attackDamage = 10;
    public int defence = 10;
    public float sightRange = 5.0f;
    public int killCount = 0;
    public float damageReduceRatio = 0f;
}
