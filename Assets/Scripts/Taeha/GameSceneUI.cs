using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSceneUI : UIBase
{


    #region Fields

    private int brokenMachines;
    private int repairMachines=0;
    private bool repairCheck;
    private float repairBar;
    public int _repairmachines { get { return repairMachines; } set { repairMachines = value; } }
    #endregion


    #region enums


    private enum Texts
    {
        Mission,
        MissionNum,
        Progress,
    }
    private enum Machines
    {
        Machine
    }
    #endregion

    private TMP_Text progress;
    public override bool Init()
    {
        if (!base.Init()) return false;

        BindText(typeof(Texts), true);
        brokenMachines = FindObjectsOfType<BrokenMachine>().Length;
        UIset();
        Main.GameManager.RepairView += Repair;
        Main.GameManager.RepairCompleteEvent += RepairComplete;
        return true;
    }

    private void RepairComplete()
    {
        repairMachines++;
        UIset();
    }

    private void UIset()
    {
        GetText((int)Texts.MissionNum).text = $"{brokenMachines} / {repairMachines}";
    }

    
    public void Repair(bool view, float repairBar)
    {
        this.repairBar = repairBar; 
        repairCheck = view;
        
        if(!repairCheck)GetText((int)Texts.Progress).text = "";
    }

    private void Update()
    {
        if (repairCheck && Main.GameManager.RePairBar < 1) GetText((int)Texts.Progress).text = $"Progress : {(Main.GameManager.RePairBar * 100).ToString("N2")}%\r\nRefair - Press Hold E";
        else if (repairCheck && Main.GameManager.RePairBar >= 1) GetText((int)Texts.Progress).text = $"Progress :Complete";
    }
}

