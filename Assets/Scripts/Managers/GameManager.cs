using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public GameData Data => _data;
    public string NickName
    {
        get => _data.nickName;
        set => _data.nickName = value;
    }
    public string CharacterType
    {
        get => _data.characterType;
        set => _data.characterType = value;
    }
    public string SkillType
    {
        get => _data.skillType;
        set => _data.skillType = value;
    }

    private GameData _data = new();
}
