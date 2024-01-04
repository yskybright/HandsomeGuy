using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : BaseScene
{
    public GameObject _playerPrefab;
    //public override void Clear()
    //{
    //    //리소스 해제
    //}

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;
        test();
        Instantiate(_playerPrefab, null);

        return true;
    }

    public void test()
    {
        Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("testGroup", (key, count, totalCount) =>
        {
            if (count >= totalCount)
            {
                Debug.Log("hjd");
                Main.DataManager.Initialize();
            }
        });
    }

    protected override void Clear()
    {
        
    }
}
