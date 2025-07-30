using UnityEngine;

public class GreenLockWife : MonoBehaviour
{
    public bool isGreenLockWifeOpened = false;

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key wife"))
        {
            Debug.Log("green lock in wife scene openedd");
            isGreenLockWifeOpened = true;
        }
        else
        {
            Debug.Log("please drop the correct key");
        }
    }
}
