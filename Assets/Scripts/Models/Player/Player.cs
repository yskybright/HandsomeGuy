using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    #region Properties

    public PlayerData playerData { get; private set; }
    public string _id { get; private set; }
    public float _currentHp { get; private set; }
    public float _maxHp { get; private set; }
    public float _moveSpeed { get; private set; }
    public float _damage { get; private set; }
    public float _attackSpeed { get; private set; }
    public float _damageReduceRatio { get; private set; }
    public float _sightRange { get; private set; }
    public int _killCount { get; private set; }

    #endregion

    #region Fileds

    //private SpriteRenderer _weaponSprite;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    //protected Animator _animator;
 

    #endregion

    #region Initialize

    private void Initialize()
    {
        // _weaponSprite = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        //_animator = GetComponent<Animator>();
    }

    public void SetInfo()
    {
        Initialize();
        playerData = Main.DataManager.Player;
        //_weaponSprite.sprite = Main.ResourceManager.GetResource<Sprite>($"{_weaponSprite.sprite.name}.sprite");
        //_animator.runtimeAnimatorController = Main.ResourceManager.GetResource<RuntimeAnimatorController>($"{key}.animController");
        //_id = playerData.id;
        _currentHp = playerData.currrentHp;
        _maxHp = playerData.maxHp;
        _moveSpeed = playerData.moveSpeed;
        _damage = playerData.damage;
        _attackSpeed = playerData.attackSpeed;
        _damageReduceRatio = playerData.damageReduceRatio;
        _sightRange = playerData.sightRange;
        _killCount = playerData.killCount;
    }

    public void SetSprite(string keyname)
    {
        GameObject.Find("MainSprite").GetComponent<SpriteRenderer>().sprite = Main.ResourceManager.GetResource<Sprite>(keyname);
    }

    #endregion


    #region ChangeMethod

    public void ChangeWeapon(string weaponName)
    {

    }

    public void ChangeId(string newId)
    {
        _id = newId;
    }

    public void ChangeCurrentHp(float newCurrentHp)
    {
        _currentHp = newCurrentHp;
    }

    public void ChangeMaxHp(float newMaxHp)
    {
        _maxHp = newMaxHp;
    }

    public void ChangeMoveSpeed(float newMoveSpeed)
    {
        _moveSpeed = newMoveSpeed;
    }

    public void ChangeDamage(float newDamage)
    {
        _damage = newDamage;
    }

    public void ChangeAttackSpeed(float newAttackSpeed)
    {
        _attackSpeed = newAttackSpeed;
    }

    public void ChangeDamageReduceRatio(float newDamageReduceRatio)
    {
        _damageReduceRatio = newDamageReduceRatio;
    }

    public void ChangeSightRange(float newSightRange)
    {
        _sightRange = newSightRange;
    }

    public void ChangeKillCount(int newKillCount)
    {
        _killCount = newKillCount;
    }
    #endregion

}
