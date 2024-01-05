using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScene_Lobby : UIScene
{
    #region enums
    private enum Objects
    {
        SceneLobbyScale,
        InputField,
    }
    private enum Buttons
    {
        StartButton,
        ReadyButton,
        ExitButton,
    }
    private enum Images
    {
        User_1_Img,
        User_2_Img,
        User_3_Img,
        User_4_Img,
        User_5_Img,
        User_6_Img,
    }
    private enum Texts
    {
        User_1_Nickname,
        User_2_Nickname,
        User_3_Nickname,
        User_4_Nickname,
        User_5_Nickname,
        User_6_Nickname,
        User_1_SkillList,
        User_2_SkillList,
        User_3_SkillList,
        User_4_SkillList,
        User_5_SkillList,
        User_6_SkillList,
    }
    #endregion

    #region Fields

    private TMP_InputField _inputField;

    #endregion
    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons), true);
        BindImage(typeof(Images), true);
        BindText(typeof(Texts), true);
        BindObject(typeof(Objects),true);

        Main.UIManager.Appear(GetObject((int)Objects.SceneLobbyScale).gameObject);
        _inputField = GetObject((int)Objects.InputField).GetComponent<TMP_InputField>();

        AddUIEvent(GetButton((int)Buttons.StartButton).gameObject, OnButtonStart);
        AddUIEvent(GetButton((int)Buttons.ReadyButton).gameObject, OnButtonReady);
        AddUIEvent(GetButton((int)Buttons.ExitButton).gameObject, OnButtonExit);

        return true;
    }

    private void OnButtonStart(PointerEventData data)
    {
        print("시작 버튼");
    }

    private void OnButtonReady(PointerEventData data)
    {
        print("준비 버튼");
    }
    private void OnButtonExit(PointerEventData data)
    {
        print("나가기 버튼");
    }

}
