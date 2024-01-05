using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pistol : WeaponItemData
{
    protected override void OnEquip(GameObject receiver)
    {
        originAtk = 5;
        originAtkSpeed = 5;
        originAtkRange = 5;
    }

    // player stat 을 직접 변경하는 방법 (대안)
    public class pistol
    {
        //_originAtk = GameManager.instance.DataManager.PlayerCurrentStats.attackSO.power;
        //GameManager.instance.UpdatePlayerAttackSODatas(0, _originAtk, 0);
    }
}



