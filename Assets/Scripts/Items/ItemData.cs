using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public enum ItemType
    {
        Weapon,
        Usable
    }

    public enum WeaponItems
    {
        Pistol,
        Rifle,
        Bow,
        Scythe,
        Hammer
    }

    public enum UsableItems
    {
        Healpack,
        Grenade,
        Dash,
        Puppet,
        Goldenkey
    }
}
