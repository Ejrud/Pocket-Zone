using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public UnityEvent<bool> OnShoot;
    public UnityEvent<InventoryItem> OnSelect;
    public static InputController instance { get; private set; }
    public Vector2 moveInput { get; private set; }
    
    public bool isShoot;

    [Header("UI")]
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private ShootButton _shootButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _useButton;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        InitButtons();
    }

    private void Update()
    {
        if (_moveJoystick.Horizontal != 0 || _moveJoystick.Vertical != 0)
        {
            moveInput = _moveJoystick.Direction;
            return;
        }

        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void InitButtons()
    {
        _shootButton.OnHold.AddListener(shoot =>
        {
            isShoot = shoot;
        });
        
        _deleteButton.onClick.AddListener(() =>
        {
            InventoryItem removeItem = InventorySystem.instance.selectedItem;
            
            if (removeItem != null)
                InventorySystem.instance.Remove(removeItem.data, removeItem.stackSize);
        });
        
        _useButton.onClick.AddListener(() =>
        {
            InventoryItem selectedItem = InventorySystem.instance.selectedItem;
            
            if (selectedItem != null)
                OnSelect?.Invoke(selectedItem);
        });
    }
}
