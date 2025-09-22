using UnityEngine;

public class ObjectStopper : MonoBehaviour
{
    public GameObject floor;
    private MeshCollider floorMeshCollider;

    void Start()
    {
        floorMeshCollider = floor.GetComponent<MeshCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("blue key husband") || other.CompareTag("green key husband") || other.CompareTag("red key husband"))
        {
            Debug.Log($"Triggered by: {other.name}, tag: {other.tag}");
            floorMeshCollider.enabled = true;

            if (other.attachedRigidbody != null)
            {
                // Nudge it upwards slightly to re-check collisions
                other.attachedRigidbody.position += Vector3.up * 0.1f;
            }
        }
    }
}
