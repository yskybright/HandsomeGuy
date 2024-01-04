using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : UIBase
{
    public override bool Init()
    {
        if (!base.Init()) return false;

        Main.UIManager.SetCanvas(gameObject, false);

        return true;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
