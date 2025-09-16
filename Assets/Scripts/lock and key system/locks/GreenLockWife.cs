using UnityEngine;

public class GreenLockWife : MonoBehaviour
{
    public static GreenLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isGreenLockWifeOpened = false;

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key wife"))
        {
            Debug.Log("green lock in wife scene openedd");
            isGreenLockWifeOpened = true;

            gateMeshCollider.enabled = false;
        }
        else
        {
            Debug.Log("please drop the correct key");
            
            gateMeshCollider.enabled = true;
        }
    }
}
