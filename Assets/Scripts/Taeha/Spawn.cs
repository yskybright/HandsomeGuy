using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn :BaseScene
{
    public override void Clear()
    {
        Main.ResourceManager.ReleaseAllAsset("GameScene");
    }
    public Transform[] points;

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        SpawnMachine(6);
        Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("GameScene", (key, count, totalCount) =>
        {
            if (count >= totalCount)
            {
                InitialAfterLoad();
            }
        });
        return true;
    }

    private void SpawnMachine(int set)
    {
        Transform[] points;
        points = GameObject.Find("GimmickSpwnPoint").GetComponentsInChildren<Transform>();
        
        int[] numbers = Enumerable.Range(1, points.Length-1).ToArray(); 
        int[] result = numbers.OrderBy(x => Random.value).Take(set).ToArray();

        for(int i = 0; i < result.Length; i++)
        {
            Main.ResourceManager.Instantiate("Machine.prefab", points[result[i]]);
        }
        Main.GameManager.UISet();
    }
    public void InitialAfterLoad()
    {
        points = GameObject.Find("PlayerSpawnGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);
        Main.ObjectManager.Spawn<Player>("Player", points[idx].position);
        Main.DataManager.SkillDict.TryGetValue(Main.GameManager.SkillType, out Data.Skill skill);
        GameObject.Find("Player(Clone)").AddComponent(skill.type);
    }
}
