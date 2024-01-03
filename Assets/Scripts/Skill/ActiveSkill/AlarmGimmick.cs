using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmGimmick : BaseSkill
{

    protected override void Start()
    {
        base.Start();
        if (Main.DataManager.SkillDict.TryGetValue("부활", out Data.Skill skill))
        {
            Debug.Log(skill.description);
        }
    }
}
