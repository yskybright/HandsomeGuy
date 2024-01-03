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
                Main.DataManager.Init();
                Init();
            }
        });
    }
    public override void Clear()
    {
        //리소스 해제
    }

    protected override void Init()
    {
        base.Init();
        Instantiate(_playerPrefab, null);
    }
}
