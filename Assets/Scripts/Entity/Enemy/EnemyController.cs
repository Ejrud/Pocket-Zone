using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Entity
{
    [SerializeField] private StorageOfVisibleObjects _storageOfVisibleObjects;

    private DropController _dropController;
    private AnimationController _animationController;
    private EnemyWeapon _enemyWeapon;
    
    private void Start()
    {
        _animationController = GetComponent<AnimationController>();
        _dropController = GetComponent<DropController>();
        _enemyWeapon = GetComponent<EnemyWeapon>();
        
        _dropController.Init(this);
        
        InitStats();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        Vector2 targetPosition = _storageOfVisibleObjects.GetClosestPosition(transform.position);
        Vector2 currentPosition = transform.position;
        
        if(targetPosition == Vector2.zero)
            return;

        Vector2 direction = (targetPosition - currentPosition).normalized;
        float distance = Vector2.Distance(currentPosition, targetPosition);

        if (distance > _enemyWeapon.GetAttackRange())
        {
            Move(direction);
        }
        else
        {
            _enemyWeapon.Attack(direction);
        }
    }
}
