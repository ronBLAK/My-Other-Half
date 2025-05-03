using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject objectToParent;

    public void Pickup(Item item)
    {
        InventoryManager.Instance.Add(item);
        gameObject.transform.SetParent(objectToParent.transform);
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Pickup(item);
    }

}
