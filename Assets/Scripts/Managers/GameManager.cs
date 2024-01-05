using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    #region Events

    public event Action<bool, float> RepairView;
    private float repairBar;

    public float RePairBar { get { return repairBar; } }
    #endregion


    public void RepairUI(bool view, float repairBar)
    {
        RepairView?.Invoke(view, repairBar);
    }
    public void Repair(float repair)
    {
        this.repairBar = repair;
    }
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
