using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : UIBase
{
    public override bool Init()
    {
        if (!base.Init()) return false;

        Main.UIManager.SetCanvas(gameObject, false);

        return true;
    }
}
