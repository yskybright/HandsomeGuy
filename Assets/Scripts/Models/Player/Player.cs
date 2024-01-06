using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    #region Properties

    public PlayerData playerData;
    public string _id;
    public float _currentHp;
    public float _maxHp;
    public float _moveSpeed;
    public float _damage;
    public float _attackSpeed;
    public float _damageReduceRatio;
    public float _sightRange;
    public int _killCount;

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

    public void SetInfo(string key)
    {
        Initialize();
        _id = key;
        playerData = Main.DataManager.Player;
        //_weaponSprite.sprite = Main.ResourceManager.GetResource<Sprite>($"{_weaponSprite.sprite.name}.sprite");
        //_animator.runtimeAnimatorController = Main.ResourceManager.GetResource<RuntimeAnimatorController>($"{key}.animController");
        _id = playerData.id;
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

    #region MonoBehaviour

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void ChangeWeapon(string weaponName)
    {

    }

    #endregion
}
