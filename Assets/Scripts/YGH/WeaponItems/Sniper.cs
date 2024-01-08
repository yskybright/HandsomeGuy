using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sniper : WeaponItemData
{
    
    protected override void OnEquip(GameObject receiver)
    {
        originAtk = 10;
        originAtkSpeed = 3;
        originAtkRange = 10;
    }
}