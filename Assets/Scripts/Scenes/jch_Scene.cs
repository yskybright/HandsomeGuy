using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : BaseScene
{
    public GameObject _playerPrefab;
    private void Start()
    {
        Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("TestScene", (key, count, totalCount) =>
        {
            if (count >= totalCount)
            {
                Main.DataManager.Initialize();
                Initialize();
            }
        });
    }
    //public override void Clear()
    //{
    //    //리소스 해제
    //}

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;
        base.Initialize();
        Instantiate(_playerPrefab, null);

        return true;
    }
}
