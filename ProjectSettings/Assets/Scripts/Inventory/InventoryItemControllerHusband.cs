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
        if (item == null)
        {
            Debug.LogWarning("attempted to drop an item when the item was null");
            return;
        }
        else if (item.itemObject == null)
        {
            Debug.LogWarning("attempted to drop an item when the item object was null");
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
