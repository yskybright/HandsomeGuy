using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsableBox : MonoBehaviour
{
    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private bool saveOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {
            OnPickedUp(other.gameObject);

            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }

            if (saveOnPickup) 
            { 
                // 소비 아이템 칸으로 이동
            }
        }
    }

    protected abstract void OnPickedUp(GameObject receiver);
}
