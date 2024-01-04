using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownInteraction : MonoBehaviour
{
    private ItemObject item;
    private TopDownCharacterController _controller;
    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        _controller.onInteractionEvent += OnInteraction;
    }

    private void OnInteraction()
    {
        if(item is IInteraction interaction)
        {
            interaction.Interaction();
        }
        // 플레이어가 아이템을 들고 있을거지? 그러면 그거를 가져와서 동작할 수 있게끔?

        // 인터페이스 하나 만들어서, 각 아이템에서 해당 상호작용을 해주는 로직

        // 인터페이스를 받아서, ㄱ오버라이딩 할  수 있도록

        // 플레이어가 뭘 가지고 있는지 해야됨.
    }
}
