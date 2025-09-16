using UnityEngine;

public class BlueLockWife : MonoBehaviour
{
    public static BlueLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isBlueLockWifeOpened = false;

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("blue key wife"))
        {
            Debug.Log("blue lock in wife scene openedd");
            isBlueLockWifeOpened = true;

            gateMeshCollider.enabled = false;
        }
        else
        {
            Debug.Log("please drop the correct key");

            gateMeshCollider.enabled = true;
        }
    }
}
// hello