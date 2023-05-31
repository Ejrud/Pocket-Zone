using UnityEngine;

[CreateAssetMenu(menuName = "InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public int stackCount;
    public ItemType itemType;

    public float damage;
    public float shootRollback;
    
    public float heal;
    public AmmoType ammoType;
}
