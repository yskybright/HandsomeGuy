using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownSkill : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private BaseActive _baseActive;
    private PhotonView _pv;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _baseActive = GetComponent<BaseActive>();
        _pv = GetComponent<PhotonView>();
    }
    private void Start()
    {
        _controller.onSkillEvent += OnSkill;
    }

    private void OnSkill()
    {
        if (_baseActive == null) return;

        if (_pv.IsMine)
        {
            _baseActive.UseSkill();
        }
    }
}
