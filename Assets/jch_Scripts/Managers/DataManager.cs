using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}
public class DataManager
{
    public Dictionary<string, Data.Skill> SkillDict { get; private set; } = new Dictionary<string, Data.Skill>();

    public void Init()
    {
        SkillDict = LoadJson<Data.SkillData, string, Skill>("skillData").MakeDict();
    }

    Loader LoadJson<Loader, K, V>(string address) where Loader : ILoader<K, V>
    {
        TextAsset textAsset = Main.ResourceManager.GetResource<TextAsset>(address);
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
