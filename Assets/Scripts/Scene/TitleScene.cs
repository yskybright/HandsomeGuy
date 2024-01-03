using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        UI = Main.UIManager.ShowSceneUI<UIScene_Title>();

        return true;
    }
}
