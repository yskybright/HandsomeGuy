using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHHScene : BaseScene
{
    public override void Clear()
    {
    }

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.ObjectManager.Spawn<Enemy>("Blue", new(7, 2));
        Main.ObjectManager.Spawn<Enemy>("Black", new(7, 1));

        return true;
    }
}
