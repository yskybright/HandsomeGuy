using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : BasePassive
{
    protected override void Init()
    {
        base.Init();
        Main.DataManager.SkillDict.TryGetValue("헤이스트", out skill);
        player.speed = player.speed * (1 + skill.increamentMoveSpeedRatio / 100f);
    }
}
