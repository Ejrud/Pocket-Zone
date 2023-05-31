using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropController : MonoBehaviour
{
    [SerializeField] private InventoryItemData[] _drop;
    private Entity _entity;

    public void Init(Entity entity)
    {
        _entity = entity;
        entity.OnEntityDie.AddListener(DropItem);
    }

    private void DropItem()
    {
        int itemIndex = Random.Range(0, _drop.Length - 1);
        Instantiate(_drop[itemIndex].prefab, transform.position, quaternion.identity);
    }

    private void OnDestroy()
    {
        if (_entity != null)
            _entity.OnEntityDie.RemoveListener(DropItem);
    }
}
