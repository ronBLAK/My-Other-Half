using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void Pickup(Item item)
    {
        InventoryManager.Instance.Add(item); // adds the item into the inventory
        Destroy(gameObject); // destroys the instance, after its been picked up, ready for respawning when dropped
    }

    private void OnMouseDown()
    {
        Pickup(item);
    }
}
