using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : MonoBehaviour
{
    public ItemData item;

    // 아이템 레이어 생성
    [SerializeField] private LayerMask supplies;

    // 주웠을 때 파괴
    [SerializeField] private bool destroyOnPickup = true;

    ItemData.WeaponItems weaponItems;
    ItemData.UsableItems usableItems;

    protected abstract void Supplies(GameObject receiver);

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
