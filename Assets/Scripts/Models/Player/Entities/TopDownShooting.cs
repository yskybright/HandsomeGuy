using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.zero;
    private PhotonView _pv;

    public GameObject testPrefab;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _controller.onAttackEvent += OnShoot;
        _controller.onLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        if (_pv.IsMine)
        {
            _aimDirection = newAimDirection;
        }
    }

    private void OnShoot()
    {
        if (_pv.IsMine)
        {
            CreateProjectile();
        }
    }

    private void CreateProjectile()
    {
        GameObject projectile = Main.PoolManager.Pop(testPrefab);
        projectile.transform.position = projectileSpawnPosition.position;
        projectile.transform.rotation = Quaternion.identity;
    }
}
