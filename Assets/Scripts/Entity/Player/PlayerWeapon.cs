using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public bool haveWeapon { get; private set; }
    [SerializeField] private SpriteRenderer _weaponImage;
    [SerializeField] private LayerMask _entityLayer;
    [SerializeField] private TMP_Text _ammoValue;
    
    private InventoryItem _weaponItem;
    private InventoryItem _ammoItem;

    private float _rollbackTimer = 0;

    public void Shoot(Vector2 direction)
    {
        if (_ammoItem == null)
            return;
        
        if (_ammoItem.stackSize <= 0)
            return;

        if (_rollbackTimer < _weaponItem.data.shootRollback)
        {
            _rollbackTimer += Time.deltaTime;
            return;
        }

        RaycastHit2D raycast = Physics2D.Raycast(_weaponImage.transform.position, direction, 100f,_entityLayer);
        if (raycast.collider != null && raycast.collider.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.SetDamage(_weaponItem.data.damage);
            _ammoItem.RemoveFromStack(1);
            _ammoValue.text = _ammoItem.stackSize.ToString();
        }
        
        _rollbackTimer = 0;
    }

    public void SetWeapon(InventoryItem weapon)
    {
        if (weapon.data.itemType != ItemType.Weapon)
        {
            return;
        }

        if (weapon == null)
        {
            RemoveWeapon();
            return;
        }

        InventorySystem.instance.Remove(weapon.data, 1);

        if (_weaponItem != null)
        {
            InventorySystem.instance.Add(_weaponItem.data);
        }

        _weaponItem = weapon;
        _rollbackTimer = _weaponItem.data.shootRollback;
        UpdateWeaponUI(_weaponItem.data.icon);
        haveWeapon = true;
    }

    public void SetAmmo(InventoryItem ammo)
    {
        if (_weaponItem == null)
            return;
        
        if (_weaponItem.data.ammoType != ammo.data.ammoType)
            return;
        
        _ammoItem = new InventoryItem(ammo.data);

        if (ammo.stackSize >= ammo.data.stackCount)
        {
            _ammoItem.AddToStack(ammo.data.stackCount);
            InventorySystem.instance.Remove(ammo.data, ammo.data.stackCount);
        }
        else
        {
            int remainderAmmo = ammo.data.stackCount - ammo.stackSize;
            _ammoItem.AddToStack(remainderAmmo);
            InventorySystem.instance.Remove(ammo.data, remainderAmmo);
        }
        
        _ammoValue.text = _ammoItem.stackSize.ToString();
    }

    private void UpdateWeaponUI(Sprite sprite)
    {
        _weaponImage.sprite = sprite;
    }

    private void RemoveWeapon()
    {
        
    }
}
