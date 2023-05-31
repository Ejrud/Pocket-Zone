using UnityEngine;

public class Item : MonoBehaviour
{
    public InventoryItemData referenceItem;
    
    public void OnHandlePickupItem()
    {
        InventorySystem.instance.Add(referenceItem);
        Destroy(gameObject);
    }
}
