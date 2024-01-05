using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bow : WeaponItemData
{
    protected override void OnEquip(GameObject receiver)
    {
        originAtk = 7;
        originAtkSpeed = 7;
        originAtkRange = 7;
    }
}