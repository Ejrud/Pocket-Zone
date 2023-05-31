using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;
    public UnityEvent OnItemsUpdated;
    public InventoryItem selectedItem { get; set; }
    public List<InventoryItem> inventory { get; private set; }
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;

    public void Awake()
    {
        if (instance != null)
        {
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }

        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack(referenceData.stackCount);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            newItem.AddToStack(referenceData.stackCount);
            inventory.Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
        }
        
        OnItemsUpdated?.Invoke();
    }

    public void Remove(InventoryItemData referenceData, int count)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack(count);

            if (value.stackSize <= 0)
            {
                inventory.Remove(value);
                _itemDictionary.Remove(referenceData);
            }
        }
        
        OnItemsUpdated?.Invoke();
    }
}
