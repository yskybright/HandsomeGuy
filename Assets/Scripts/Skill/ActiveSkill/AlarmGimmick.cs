using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmGimmick : BaseActive
{
    IEnumerator SteamPackCoroutine()
    {
        isSkillCool = true;

        yield return new WaitForSeconds(skill.coolTime);

        isSkillCool = false;
    }
    protected override void Init()
    {
        base.Init();
        if (!Main.DataManager.SkillDict.TryGetValue("기계광", out skill))
        {
            Debug.Log("해당 스킬을 가져오는데 실패하였습니다.");
        }
    }

    public override void UseSkill()
    {
        if (isSkillCool) return;
        base.UseSkill();
        StartCoroutine(SteamPackCoroutine());
    }
}
