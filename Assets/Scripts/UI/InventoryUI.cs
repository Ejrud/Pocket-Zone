using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EasyButtons;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    
    [Header("Buttons")]
    [SerializeField] private GameObject _useButtonObj;
    [SerializeField] private GameObject _deleteButtonObj;

    [Header("Links")]
    [SerializeField] private ItemUI[] _items;
    
    private void Awake()
    {
        foreach (ItemUI item in _items)
        {
            item.Init(this);
        }
        
        InventorySystem.instance.OnItemsUpdated.AddListener(SyncItems);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void OnItemSelected(InventoryItem item)
    {
        if (item is null)
        {
            _itemImage.color = new Vector4(1, 1, 1, 0);
            _itemName.text = "";
            _itemDescription.text = "";
            _useButtonObj.gameObject.SetActive(false);
            _deleteButtonObj.gameObject.SetActive(false);
            InventorySystem.instance.selectedItem = null;
            return;
        }
        
        _itemImage.color = new Vector4(1, 1, 1, 1);
        _itemImage.sprite = item.data.icon;
        _itemName.text = item.data.title;
        _itemDescription.text = item.data.description;
        _useButtonObj.gameObject.SetActive(true);
        _deleteButtonObj.gameObject.SetActive(true);
        InventorySystem.instance.selectedItem = item;
    }

    private void SyncItems()
    {
        List<InventoryItem> inventoryItems = InventorySystem.instance.inventory;
        int counter = 0;
        
        foreach (ItemUI item in _items)
        {
            if (counter < inventoryItems.Count)
            {
                item.UpdateItem(inventoryItems[counter]);
            }
            else
            {
                item.SetClear();
            }

            counter++;
        }

        OnItemSelected(null);
    }

    private void OnEnable()
    {
        SyncItems();
        OnItemSelected(null);
    }
}
