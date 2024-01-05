using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override void Clear()
    {
    }
    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;
        print($"닉네임 : {Main.GameManager.NickName}, 캐릭터 : {Main.GameManager.CharacterType}, 스킬 : {Main.GameManager.SkillType}");

        UI = Main.UIManager.ShowSceneUI<UIScene_Lobby>();
        return true;
    }
}
