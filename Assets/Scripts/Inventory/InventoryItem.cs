using System;

[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
    }

    public void AddToStack(int count)
    {
        stackSize += count;
    }

    public void RemoveFromStack(int count)
    {
        stackSize -= count;
    }
}
