using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UIBase
{
    public override bool Init()
    {
        if (!base.Init()) return false;

        Main.UIManager.SetCanvas(gameObject, true);

        return true;
    }
}
