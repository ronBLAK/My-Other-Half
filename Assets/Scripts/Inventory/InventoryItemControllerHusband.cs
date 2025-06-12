using UnityEngine;
using UnityEngine.UI;

public class InventoryItemControllerHusband : MonoBehaviour
{
    Item item; // reference to the item script

    public void RemoveItem()
    {
        InventoryManagerHusband.instance.Remove(item); // removes the item from the inventory

        Destroy(gameObject); // destroys the item after removal

        InventoryManagerHusband.instance.SaveInventory(); // saves the inventory when an item is removed/dropped
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
            case Item.ItemType.BlueKeyHusband:
                Husband.instance.DropBlueKey(item.itemObject);
                break;

            case Item.ItemType.GreenKeyHusband:
                Husband.instance.DropGreenKey(item.itemObject);
                break;

            case Item.ItemType.RedKeyHusband:
                Husband.instance.DropRedKey(item.itemObject);
                break;
        }

        RemoveItem();
    }
}
