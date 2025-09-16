using UnityEngine;

public class GreenLockHusband : MonoBehaviour
{
    public static GreenLockHusband instance;

    public GameObject keyGate; // reference to the obejct that should block the wrong key from going through
    private MeshCollider gateMeshCollider;

    public bool isGreenLockHusbandOpened = false; // flag to check if the green lock has been opened by the husband

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key husband"))
        {
            Debug.Log("green lock in husband scene opened");
            isGreenLockHusbandOpened = true;

            // the mesh collider of the key gate is by default enabled, so we need to disable it to allow the key to pass through
            gateMeshCollider.enabled = false;
        }
        else
        {
            Debug.Log("please drop the correct key");

            // set mesh collider of gate to true just in case it was previously disabled
            gateMeshCollider.enabled = true;
        }
    }
}
