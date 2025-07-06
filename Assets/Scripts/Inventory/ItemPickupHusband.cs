using UnityEngine;

public class ItemPickupHusband : MonoBehaviour
{
    public Item item;

    private void Pickup()
    {
        InventoryManagerHusband.instance.Add(item); // adds the clicked item to the inventory

        Destroy(gameObject); // destroys the item prefab that corresponds with the item that is picked up

        InventoryManagerHusband.instance.SaveInventory(); // saves the inventory when a new item is picked up and added to inventory
    }

    private void OnMouseDown()
    { 
        Pickup();
    }
}
