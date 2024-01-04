using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public WeaponItemData WeaponData;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;
    private float _originAtk;
    private float _originAttackSpeed;
    private float _originAttackRange;
    private float _changeAtk;
    private float _changeAttackSpeed;
    private float _changeAttackRange;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UseItem();
        }
    }

    public void UseItem()
    {

        switch (WeaponData.weaponType)
        {
            case WeaponType.Pistol:
                PistolWeapon();
                break;

            case WeaponType.Rifle:
                RifleWeapon();
                break;

            case WeaponType.Hammer:
                HammerWeapon();
                break;

            default:
                break;
        }
    }

    #region Item

    // Pistol 기본 무기
    public void PistolWeapon()
    {
        //_originAtk = GameManager.instance.DataManager.PlayerCurrentStats.attackSO.power;
        //GameManager.instance.UpdatePlayerAttackSODatas(0, _originAtk, 0);
    }

    // Rifle 공격력 증가, 사거리 증가, 공격속도 증가
    public void RifleWeapon()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 0);
        _circleCollider.enabled = false;

        // 기본 공격
        _originAttackSpeed = GameManager.instance.DataManager.PlayerCurrentStats.attackSO.attackSpeed;
        _changeAttackSpeed = _originAttackSpeed / 2;
        GameManager.instance.UpdatePlayerAttackSODatas(-_changeAttackSpeed, 0, 0);

        // 스킬 공격
        foreach (SkillItemData skill in GameManager.instance.DataManager.SkillDataList)
        {
            skill.Atk *= 2;
        }

        StartCoroutine(RestorePower());
    }

    // 5초 동안, 스피드 1.5배
    public void HammerWeapon()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 0);
        _circleCollider.enabled = false;
        _colorChange.PlayerColorChange(new Color(86 / 255f, 106 / 255f, 255 / 255f, 255 / 255f));

        _originSpeed = GameManager.instance.DataManager.PlayerCurrentStats.speed;
        _changeSpeed = (int)(_originSpeed / 2);
        GameManager.instance.UpdatePlayerStatsDatas(0, 0, _changeSpeed);

        StartCoroutine(RestoreSpeed());
    }

    // 데미지 복구
    IEnumerator HammerWeapon2()
    {
        yield return new WaitForSeconds(5f);

        // 기본 공격
        GameManager.instance.UpdatePlayerAttackSODatas(0, -_originAtk, 0);

        // 스킬
        foreach (SkillItemData skill in GameManager.instance.DataManager.SkillDataList)
        {
            skill.Atk /= 2;
        }

        Destroy(gameObject);
    }

    // 사거리 복구
    IEnumerator RestoreSpeed()
    {
        yield return new WaitForSeconds(5f);

        GameManager.instance.UpdatePlayerStatsDatas(0, 0, -_changeSpeed);

        Destroy(gameObject);
    }

    // 공격 속도 복구
    IEnumerator RestoreAttackSpeed()
    {
        yield return new WaitForSeconds(5f);

        // 기본 공격 속도 복구
        GameManager.instance.UpdatePlayerAttackSODatas(_changeAttackSpeed, 0, 0);

        // 스킬 속도 복구
        foreach (SkillItemData skill in GameManager.instance.DataManager.SkillDataList)
        {
            skill.CoolTime *= 2;
        }

        Destroy(gameObject);
    }
    #endregion

    //private class Pistol : IWeapons
    //{
    //    public string Name { get; set; } = string.Empty;
    //    string name;
    //    int damage;
    //    int attackspeed;
    //    int attackrange;
    //}

    //// Class EquipItems;
    // Duration = 30s;

    //// IWeapon
    // attackDamage, attackRange, attackSpeed

    //1. Pistol (5, 5, 5)
    //2. Rifle, (8, 7, 7)
    //3. Bow, (7, 7, 3)
    //4. Scythe, (10, 2, 2)
    //5. Hammer, (15, 1, 2)


}



