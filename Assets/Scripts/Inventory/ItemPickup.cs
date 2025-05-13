using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Pickup()
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
