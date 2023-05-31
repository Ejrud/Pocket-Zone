using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour, IDamageable
{
    public UnityEvent OnEntityDie;
    public bool isDead { get; private set; }


    [Header("Settings")] 
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _bodyCollider;
    [SerializeField] private ProgressBar _healthBar;

    private float _health;

    public void InitStats()
    {
        _health = _maxHealth;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _moveSpeed;
    }

    public void SetDamage(float value)
    {
        if (value < 0)
        {
            Debug.LogError("Damage cannot heal");
            return;
        }
        
        _health -= value;
        
        if (_health <= 0)
        {
            _health = 0;
            _bodyCollider.enabled = false;
            OnEntityDie?.Invoke();
            isDead = true;
        }
        
        _healthBar.SetValue(_health, _maxHealth);
    }
}
