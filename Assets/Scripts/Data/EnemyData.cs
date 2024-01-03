using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string key;
    public float HP;
    public float Speed;
    public float Damage;
}

[Serializable]
public class EnemyDataLoader : ILoader<string, EnemyData>
{
    public List<EnemyData> Enemies = new();
    public Dictionary<string, EnemyData> MakeDictionary()
    {
        Dictionary<string, EnemyData> dictionary = new();
        foreach (EnemyData Enemy in Enemies)
        {
            dictionary.Add(Enemy.key, Enemy);
        }
        return dictionary;
    }
}
