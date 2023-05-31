using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent<Item>(out Item item))
        {
            return;
        }
        
        item.OnHandlePickupItem();
    }
}
