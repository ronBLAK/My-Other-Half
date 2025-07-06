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
