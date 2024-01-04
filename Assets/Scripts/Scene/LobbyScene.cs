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

        UI = Main.UIManager.ShowSceneUI<UIScene_Lobby>();
        return true;
    }
}
