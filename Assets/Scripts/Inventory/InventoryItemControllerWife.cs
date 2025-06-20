using UnityEngine;
using UnityEngine.UI;

public class InventoryItemControllerWife : MonoBehaviour
{
    Item item; // reference to the item script

    public void RemoveItem()
    {
        InventoryManagerWife.instance.Remove(item); // removes the item from the inventory

        Destroy(gameObject); // destroys the item after removal

        InventoryManagerWife.instance.SaveInventory(); // saves the inventory when an item is removed/dropped
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void DropItem()
    {
        if (item == null || item.itemObject == null)
        {
            Debug.LogWarning("Attempted to drop an item that no longer exists.");
            return;
        }

        switch (item.itemType)
        {
            case Item.ItemType.BlueKeyWife:
                Wife.instance.DropBlueKey(item.itemObject);
                break;

            case Item.ItemType.GreenKeyWife:
                Wife.instance.DropGreenKey(item.itemObject);
                break;

            case Item.ItemType.RedKeyWife:
                Wife.instance.DropRedKey(item.itemObject);
                break;
        }

        RemoveItem();
    }
}
