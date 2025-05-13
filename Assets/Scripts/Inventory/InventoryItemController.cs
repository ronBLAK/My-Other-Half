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
}
