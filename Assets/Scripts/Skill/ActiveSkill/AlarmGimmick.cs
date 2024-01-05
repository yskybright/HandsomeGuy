using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmGimmick : BaseActive
{

    protected override void Init()
    {
        if (Main.DataManager.SkillDict.TryGetValue("부활", out Data.Skill skill))
        {
            Debug.Log(skill.description);
        }
    }
}
