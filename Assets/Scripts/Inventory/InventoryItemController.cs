using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item; // reference to the item script

    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item); // removes the item from the inventory

        Destroy(gameObject); // destroys the item after removal
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void DropItem()
    {
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
