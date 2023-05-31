using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _rollback;
    [SerializeField] private float _damage;

    private float _rollbackTimer;

    public void Attack(Vector2 direction)
    {
        if (_rollbackTimer < _rollback)
        {
            _rollbackTimer += Time.deltaTime;
            return;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _attackDistance, _targetLayer);
        if (hit.collider != null && hit.collider.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.SetDamage(_damage);
        }

        _rollbackTimer = 0;
    }

    public float GetAttackRange()
    {
        return _attackDistance;
    }
}
