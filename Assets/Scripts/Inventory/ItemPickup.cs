using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Pickup()
    {
        InventoryManager.instance.Add(item); // adds the clicked item to the inventory

        Destroy(gameObject); // destroys the item prefab that corresponds with the item that is picked up

        InventoryManager.instance.SaveInventory(); // saves the inventory when a new item is picked up and added to inventory
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
