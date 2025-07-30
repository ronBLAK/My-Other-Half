using UnityEngine;

public class RedLockWife : MonoBehaviour
{
    public bool isRedLockWifeOpened = false;

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("red key wife"))
        {
            Debug.Log("red lock in wife scene openedd");
            isRedLockWifeOpened = true;
        }
        else
        {
            Debug.Log("please drop the correct key");
        }
    }
}
