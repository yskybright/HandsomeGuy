using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보급상자의 생성, 획득, 파괴
/// 아이템 획득, 사용, 파괴
/// </summary>

public abstract class ItemObject : MonoBehaviour, IInteraction
{
    // 닿으면 상자 파괴
    [SerializeField] private bool destroyOnPickup = true;

    [SerializeField] private LayerMask saveOnPickup;

    // 아이템 레이어 생성
    [SerializeField] private LayerMask supplies;

    


    public virtual void Interaction()
    {

    }

    protected abstract void Supplies(GameObject receiver);

    // 아이템 획득
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 조건) 아이템 레이어라면 
        if (supplies.value == (supplies.value | (1 << other.gameObject.layer)))
        {
            Supplies(other.gameObject);

            // 조건) 장착 아이템이라면
            // if (items == equipitems)
            {
                // 기본 총 해제, 아이템 장착
            }

            // 조건) 소비 아이템이라면
            // if (items == usableitems)
            {
                // 소비 아이템 칸에 아이템 등록
            }
            Destroy(gameObject);
        }
    }
}

// 

//    #region Item

//    // Pistol 기본 무기
//    public void PistolWeapon()
//    {
//        //_originAtk = GameManager.instance.DataManager.PlayerCurrentStats.attackSO.power;
//        //GameManager.instance.UpdatePlayerAttackSODatas(0, _originAtk, 0);
//    }

//    // Rifle 공격력 증가, 사거리 증가, 공격속도 증가
//    public void RifleWeapon()
//    {
//        _spriteRenderer.color = new Color(255, 255, 255, 0);
//        _circleCollider.enabled = false;

//        // 기본 공격
//        _originAttackSpeed = GameManager.instance.DataManager.PlayerCurrentStats.attackSO.attackSpeed;
//        _changeAttackSpeed = _originAttackSpeed / 2;
//        GameManager.instance.UpdatePlayerAttackSODatas(-_changeAttackSpeed, 0, 0);

//        // 스킬 공격
//        foreach (SkillItemData skill in GameManager.instance.DataManager.SkillDataList)
//        {
//            skill.Atk *= 2;
//        }

//        StartCoroutine(RestorePower());
//    }

//    // 5초 동안, 스피드 1.5배
//    public void HammerWeapon()
//    {
//        _spriteRenderer.color = new Color(255, 255, 255, 0);
//        _circleCollider.enabled = false;
//        _colorChange.PlayerColorChange(new Color(86 / 255f, 106 / 255f, 255 / 255f, 255 / 255f));

//        _originSpeed = GameManager.instance.DataManager.PlayerCurrentStats.speed;
//        _changeSpeed = (int)(_originSpeed / 2);
//        GameManager.instance.UpdatePlayerStatsDatas(0, 0, _changeSpeed);

//        StartCoroutine(RestoreSpeed());
//    }

//    // 공격력 복구
//    IEnumerator HammerWeapon2()
//    {
//        yield return new WaitForSeconds(5f);

//        // 기본 공격
//        GameManager.instance.UpdatePlayerAttackSODatas(0, -_originAtk, 0);

//        // 스킬
//        foreach (SkillItemData skill in GameManager.instance.DataManager.SkillDataList)
//        {
//            skill.Atk /= 2;
//        }

//        Destroy(gameObject);
//    }

//    // 사거리 복구
//    IEnumerator RestoreSpeed()
//    {
//        yield return new WaitForSeconds(5f);

//        GameManager.instance.UpdatePlayerStatsDatas(0, 0, -_changeSpeed);

//        Destroy(gameObject);
//    }

//    // 공격속도 복구
//    IEnumerator RestoreAttackSpeed()
//    {
//        yield return new WaitForSeconds(5f);

//        // 공격속도 복구
//        GameManager.instance.UpdatePlayerAttackSODatas(_changeAttackSpeed, 0, 0);


//        Destroy(gameObject);
//    }
//    #endregion


// 성규님 작성
//public class gun2 : ItemObject
//{
//    public override void Interaction()
//    {
//        base.Interaction();
//        // 소총 상호작용 함수

//        // 소총 능력치 반영
//        // 갈아끼우는 작업
//    }
//}

