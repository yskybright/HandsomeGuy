using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UIBase
{
    public virtual void Init()
    {
        Main.UIManager.SetCanvas(gameObject, true);
    }
}
