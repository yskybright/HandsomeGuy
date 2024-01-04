using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipBox : MonoBehaviour
{
    [SerializeField] private bool saveOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {
            OnPickedUp(other.gameObject);

            if (saveOnPickup)
            {
                // 장착 아이템 칸으로 이동
            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
