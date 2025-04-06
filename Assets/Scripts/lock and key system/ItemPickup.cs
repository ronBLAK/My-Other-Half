using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private GameObject keyHolderPivot;

    private void Start()
    {
        keyHolderPivot = GameObject.FindWithTag("key holder");
    }

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        gameObject.transform.SetParent(keyHolderPivot.transform);
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Center of screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f)) // You can set your own max range
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);

            Pickup();
        }
    }
}
