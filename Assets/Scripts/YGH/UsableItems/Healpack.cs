using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Healpack : UsableItemData
{
    [SerializeField] int healValue = 10;
    //private HealthSystem _healthSystem;

    protected override void OnUse(GameObject receiver)
    {
        // 플레이어의 HP 변수 가져오기
        //_healthSystem = receiver.GetComponent<HealthSystem>();
        //_healthSystem.ChangeHealth(healValue);
    }
}


