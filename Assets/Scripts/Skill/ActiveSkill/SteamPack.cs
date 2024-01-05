using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPack : BaseActive
{
    //플레이어의 원래 공격속도 temp 필드 추가
    IEnumerator SteamPackCoroutine()
    {
        isSkillCool = true;
        //플레이어의 스텟 증가 ( 공격속도 50% )

        yield return new WaitForSeconds(skill.coolTime);

        //플레이어의 스텟 원래대로

        isSkillCool = false;
    }
    protected override void Init()
    {
        base.Init();
        if (Main.DataManager.SkillDict.TryGetValue("스팀팩", out skill))
        {
            Debug.Log("해당 스킬을 가져오는데 실패하였습니다.");
        }
    }

    protected override void UseSkill()
    {
        if (isSkillCool) return;
        base.UseSkill();
        StartCoroutine(SteamPackCoroutine());
    }
}
