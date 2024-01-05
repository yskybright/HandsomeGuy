using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendSight : BasePassive
{
    private GimmickMissionController _gimmickMissionController;
    private float _tempPlayerSight;
    protected override void Init()
    {
        base.Init();
        Main.DataManager.SkillDict.TryGetValue("선택적 올빼미", out skill);
        _tempPlayerSight = player.sightRange;
        _gimmickMissionController = gameObject.GetComponent<GimmickMissionController>();
        _gimmickMissionController.missionEvent += StartCoroutineAfterCheck;
    }

    IEnumerator IncreamentPlayerSightCoroutine()
    {
        IncreamentPlayerSight();

        yield return new WaitForSeconds(skill.duration);

        player.sightRange = _tempPlayerSight;
    }

    private void IncreamentPlayerSight()
    {
        player.sightRange = player.sightRange + skill.increamentSightRange;
    }

    public void StartCoroutineAfterCheck(bool isSuccessMission)
    {
        if (!isSuccessMission) return;

        StartCoroutine(IncreamentPlayerSightCoroutine());
    }
}
