using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Pistol,
    Rifle,
    Hammer
}

[CreateAssetMenu(fileName = "WeaponItemData_", menuName = "Data/WeaponItemData", order = 1)]

public class WeaponItemData : ItemData
{
        [Header("WeaponType")]
        public WeaponType weaponType;

        [Header("Stats")]
        public float Attack;
        public float AttackSpeed;
        public float AttackRange;
}