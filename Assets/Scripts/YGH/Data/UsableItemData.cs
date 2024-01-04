using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UsableType
{
    Healpack,
    Grenade,
    Dash,
    Puppet,
    //Goldenkey
}

[CreateAssetMenu(fileName = "UsableItemData_", menuName = "Data/UsableItemData", order = 2)]

public class UsableItemData : ItemData
{
    [Header("UsableType")]
    public UsableType usableType;

    [Header("Stats")]
    public float Hp;
    public float Attack;
    public float ItemPosition;
    public float CharacterPosition;
}