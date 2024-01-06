using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JangChungDong : BasePassive
{

    protected override void Init()
    {
        base.Init();
        if (!Main.DataManager.SkillDict.TryGetValue("장충동 왕 족발 보쌈", out skill))
        {
            Debug.Log("해당 스킬을 가져오는데 실패하였습니다.");
            return;
        }
        player._moveSpeed = player._moveSpeed * (1 + skill.increamentMoveSpeedRatio / 100f);
        player._sightRange = skill.increamentSightRange;
        player._damageReduceRatio = skill.reductionDamageRatio;
        player._damage += player._damage * (1 + skill.increamentDamage / 100f);
    }
}
