using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField] private StorageOfVisibleObjects _storageOfVisibleObjects;
    
    
    private InputController _inputController;
    private AnimationController _animationController;
    private PlayerWeapon _playerWeapon;
    private ArmRotation _armRotation;

    private void Start()
    {
        _inputController = InputController.instance;
        _animationController = GetComponent<AnimationController>();
        _playerWeapon = GetComponent<PlayerWeapon>();
        _armRotation = GetComponent<ArmRotation>();
        
        _inputController.OnSelect.AddListener(UseItem);
        
        InitStats();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        Vector2 moveDirection = _inputController.moveInput;
        Vector2 targetPosition = _storageOfVisibleObjects.GetClosestPosition(transform.position);

        _animationController.Animate(moveDirection);
        
        if (!_playerWeapon.haveWeapon)
            return;
        
        _armRotation.SetRotation(targetPosition); 
        PrepareShoot(_inputController.isShoot);
    }
    
    private void PrepareShoot(bool isShoot)
    {
        if (isShoot)
        {
            _playerWeapon.Shoot(_armRotation.GetDirection());
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Move(_inputController.moveInput);
    }

    private void UseItem(InventoryItem item)
    {
        switch (item.data.itemType)
        {
            case ItemType.Weapon:
                _playerWeapon.SetWeapon(item);
                break;
            
            case ItemType.Ammo:
                _playerWeapon.SetAmmo(item);
                break;
        }
    }
}
