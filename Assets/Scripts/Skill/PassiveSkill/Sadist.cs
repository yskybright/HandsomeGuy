using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sadist : BasePassive
{
    private int nextGoalKill;
    private int stack;

    protected override void Init()
    {
        base.Init();
        Main.DataManager.SkillDict.TryGetValue("사디스트", out skill);
        stack = 1;
        nextGoalKill = skill.increamentUnit * stack;
    }

    private void Update()
    {
        if (player.killCount >= nextGoalKill)
        {
            UpdatePlayerAttackDamage();
        }
    }

    public void UpdatePlayerAttackDamage()
    {
        player.damage += skill.increamentDamage;
        stack++;
        nextGoalKill = skill.increamentUnit * stack;
    }
}
