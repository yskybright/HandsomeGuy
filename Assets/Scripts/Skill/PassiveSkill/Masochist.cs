using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masochist : BasePassive
{
    protected override void Init()
    {
        base.Init();
        Main.DataManager.SkillDict.TryGetValue("마조히스트", out skill);
        player.damageReduceRatio = 10.0f;
    }
}
