using UnityEngine;

public class ItemPickUpCommon : MonoBehaviour
{
    private void Pickup()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
