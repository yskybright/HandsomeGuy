using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPopup_SelectSkill : UIPopup
{
    #region Enums
    private enum Objects
    {
        PopupSelectSkillScale,
    }
    private enum Buttons
    {
        Skill_1,
        Skill_2,
        Skill_3,
    }
    private enum Images
    {
        Skill1_Icon,
        Skill2_Icon,
        Skill3_Icon,
    }
    private enum Texts
    {
        Skill1_Name,
        Skill2_Name,
        Skill3_Name,
        Skill1_Desc,
        Skill2_Desc,
        Skill3_Desc,
    }

    #endregion

    #region Fields
    private GameObject scaler;

    #endregion
    void Start()
    {
        Init();
    }
    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons), true);
        BindObject(typeof(Objects), true);
        BindText(typeof(Texts), true);
        BindImage(typeof(Images), true);

        scaler = GetObject((int)Objects.PopupSelectSkillScale);
        AddUIEvent(GetButton((int)Buttons.Skill_1).gameObject, OnButtonSkill);
        AddUIEvent(GetButton((int)Buttons.Skill_2).gameObject, OnButtonSkill);
        AddUIEvent(GetButton((int)Buttons.Skill_3).gameObject, OnButtonSkill);

        Main.UIManager.Appear(scaler);
        return true;
    }

    private void OnButtonSkill(PointerEventData data)
    {
        print(data.selectedObject);
        StartCoroutine(CoButtonSkill());
    }
    IEnumerator CoButtonSkill()
    {
        Main.UIManager.Hide(scaler);
        yield return new WaitForSeconds(1f);
        Main.SceneManagerEx.LoadScene(Define.Scene.LobbyScene);
    }
}
