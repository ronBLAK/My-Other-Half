using UnityEngine;

public class RedLockWife : MonoBehaviour
{
    public static RedLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isRedLockWifeOpened = false;

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("red key wife"))
        {
            Debug.Log("red lock in wife scene openedd");
            isRedLockWifeOpened = true;

            gateMeshCollider.enabled = false;
        }
        else
        {
            Debug.Log("please drop the correct key");

            gateMeshCollider.enabled = true;
        }
    }
}
