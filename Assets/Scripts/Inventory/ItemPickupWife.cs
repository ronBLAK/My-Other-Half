using UnityEngine;

public class ItemPickupWife : MonoBehaviour
{
    public Item item;

    private void Pickup()
    {
        InventoryManagerWife.instance.Add(item); // adds the clicked item to the inventory

        Destroy(gameObject); // destroys the item prefab that corresponds with the item that is picked up

        InventoryManagerWife.instance.SaveInventory(); // saves the inventory when a new item is picked up and added to inventory
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
