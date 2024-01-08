using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn :BaseScene
{
    private EnemySpawn enemySpawn;

    public override void Clear()
    {
        Main.ResourceManager.ReleaseAllAsset("GameScene");
    }
    public Transform[] playerpoints;
    public Transform[] gimmickpoints;

    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        if (enemySpawn == null) enemySpawn = this.gameObject.GetOrAddComponent<EnemySpawn>();

        SpawnMachine(6);
        Main.ResourceManager.LoadAllAsync<UnityEngine.Object>("GameScene", (key, count, totalCount) =>
        {
            if (count >= totalCount)
            {
                
            }
        });
        InitialAfterLoad();
        Main.ResourceManager.Instantiate($"NavMesh.prefab");
        StartWave();

        return true;
    }

    private void SpawnMachine(int set)
    {

        gimmickpoints = GameObject.Find("GimmickSpwnPoint").GetComponentsInChildren<Transform>();

        int[] numbers = Enumerable.Range(1, gimmickpoints.Length - 1).ToArray();
        int[] result = numbers.OrderBy(x => Random.value).Take(set).ToArray();

        for (int i = 0; i < result.Length; i++)
        {
            Main.ResourceManager.Instantiate("Machine.prefab", gimmickpoints[result[i]]);
        }
        Main.GameManager.UISet();
    }
    public void InitialAfterLoad()
    {
        playerpoints = GameObject.Find("PlayerSpawnGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, playerpoints.Length);
        Main.ObjectManager.Spawn<Player>("Player", playerpoints[idx].position);
        Main.DataManager.SkillDict.TryGetValue(Main.GameManager.SkillType, out Data.Skill skill);
        GameObject.Find("Player(Clone)").AddComponent(skill.type);
    }

    private void StartWave()
    {
        enemySpawn.StartSpawn();
    }
}
