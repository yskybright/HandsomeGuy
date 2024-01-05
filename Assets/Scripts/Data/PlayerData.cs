using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string id;
    public float hp;
    public float moveSpeed;
    public float damage;
    public float attackSpeed;
}

[Serializable]
public class PlayerDataLoader : ILoader<string, PlayerData>
{
    public List<PlayerData> Players = new();
    public Dictionary<string, PlayerData> MakeDictionary()
    {
        Dictionary<string, PlayerData> dictionary = new();
        foreach (PlayerData Player in Players)
        {
            dictionary.Add(Player.id, Player);
        }
        return dictionary;
    }
}
