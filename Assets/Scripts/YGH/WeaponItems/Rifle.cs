using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rifle : WeaponItemData
{
    protected override void OnEquip(GameObject receiver)
    {
        originAtk = 9;
        originAtkSpeed = 9;
        originAtkRange = 9;
    }
}