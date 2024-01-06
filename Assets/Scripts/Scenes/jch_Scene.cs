using Data;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : BaseScene
{
    public GameObject _playerPrefab;
    public Transform[] points;

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;
        SceneType = Define.Scene.Game;
        test();

        points = GameObject.Find("PlayerSpawnGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        

        Main.ObjectManager.Spawn<Player>("Player", points[idx].position);
        Main.DataManager.SkillDict.TryGetValue(Main.GameManager.SkillType, out Data.Skill skill);
        GameObject.Find("Player(Clone)").AddComponent(skill.type);


        return true;
    }

    public void test()
    {
        Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("testGroup", (key, count, totalCount) =>
        {
            if (count >= totalCount)
            {
                Main.DataManager.Initialize();
            }
        });
    }

    public override void Clear()
    {
        Debug.Log("Clear TestScene");
    }
}
