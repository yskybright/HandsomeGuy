using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : BaseActive
{
    //플레이어의 원래 sprite 투명도 temp 필드 추가
    Color tempColor;
    //Color currentColor = player.spriteRenderer.color;
    IEnumerator InvisibleManCoroutine()
    {
        isSkillCool = true;
        Color invisibleColor = tempColor;
        invisibleColor.a = invisibleColor.a * 0.5f;
        //플레이어의 스프라이트 투명도 감소
        //player.spriteRenderer.color = invisibleColor;

        yield return new WaitForSeconds(skill.coolTime);

        //플레이어의 스프라이트 투명도 원래대로

        //player.spriteRenderer.color = tempColor;

        isSkillCool = false;
    }
    protected override void Init()
    {
        base.Init();
        if (Main.DataManager.SkillDict.TryGetValue("투명인간", out skill))
        {
            Debug.Log("해당 스킬을 가져오는데 실패하였습니다.");
        }
    }

    protected override void UseSkill()
    {
        if (isSkillCool) return;
        base.UseSkill();
        StartCoroutine(InvisibleManCoroutine());
    }
}
