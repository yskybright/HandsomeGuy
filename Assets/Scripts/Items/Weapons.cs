using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapons
{
    private class Pistol : IWeapons
    {
        public string Name { get; set; } = string.Empty;
        string name;
        int damage;
        int attackspeed;
        int attackrange;
    }

    //// Class EquipItems;
    // Duration = 30s;

    //// IWeapon
    // attackDamage, attackRange, attackSpeed

    //1. Pistol (4, 4, 4)
    //2. Rifle, (8, 7, 7)
    //3. Bow, (7, 7, 5)
    //4. Scythe, (10, 2, 2)
    //5. Hammer, (15, 1, 2)



}



