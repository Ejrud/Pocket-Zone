using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour
{
    public InventoryItem referenceData { get; private set; }
    private InventoryUI _inventroyUI;

    [Header("UI")] 
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private Button _button;
    
    public void UpdateItem(InventoryItem newData)
    {
        referenceData = newData;
        _itemIcon.sprite = referenceData.data.icon;
        _itemIcon.color = new Vector4(1, 1, 1, 1);
        
        _countText.text = (referenceData.stackSize == 1) ? "" : referenceData.stackSize.ToString();
    }

    public void SetClear()
    {
        _itemIcon.sprite = null;
        _itemIcon.color = new Vector4(1, 1, 1, 0);
        _countText.text = "";
    }

    public void Init(InventoryUI inventoryUI)
    {
        _inventroyUI = inventoryUI;
        _button.onClick.AddListener(() => { _inventroyUI.OnItemSelected(referenceData); });
    }
}
