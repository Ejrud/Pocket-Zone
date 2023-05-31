using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    Enemy,
    Player,
}

public class StorageOfVisibleObjects : MonoBehaviour
{
    [SerializeField] private Tag _tagLayer;
    private HashSet<AimTarget> _storage = new HashSet<AimTarget>();

    public void DeleteItem(AimTarget target)
    {
        if (_storage.Contains(target))
        {
            _storage.Remove(target);
        }
    }

    public Vector2 GetClosestPosition(Vector2 originPosition)
    {
        float minDistance = 1000f;
        Vector2 closestPosition = Vector2.zero;
        
        foreach (AimTarget unit in _storage)
        {
            float distance = Vector3.Distance(unit.transform.position, originPosition);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestPosition = unit.transform.position;
            }
        }

        return closestPosition;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.transform.CompareTag(_tagLayer.ToString()))
            return;
        
        if (col.TryGetComponent<AimTarget>(out AimTarget aimTarget))
        {
            _storage.Add(aimTarget);
            aimTarget.Init(this);
            // Debug.Log($"Enemy \"{aimTarget.name}\" added to the repository");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<AimTarget>(out AimTarget aimTarget))
        {
            DeleteItem(aimTarget);
        }
    }
}
