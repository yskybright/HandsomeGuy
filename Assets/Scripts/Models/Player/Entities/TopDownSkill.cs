using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownSkill : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    private void Start()
    {
        _controller.onSkillEvent += OnSkill;
    }

    private void OnSkill()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<BaseActive>().UseSkill;
    }
}
