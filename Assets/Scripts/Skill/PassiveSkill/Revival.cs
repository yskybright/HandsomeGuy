using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revival : BasePassive
{
    private int revivalCount;

    protected override void Init()
    {
        base.Init();
        revivalCount = 1;
        Main.DataManager.SkillDict.TryGetValue("부활", out skill);
    }

    private void Update()
    {
        if (player.hp <= 0 && revivalCount != 0)
        {
            player.hp = Mathf.RoundToInt((player.maxHp / 100.0f) * skill.revivalHealthRatio);
            revivalCount--;
        }
        Debug.Log(player.hp);
    }
}
