using UnityEngine;

public class RedLockHusband : MonoBehaviour
{
    public bool isRedLockHusbandOpened = false;

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("red key husband"))
        {
            Debug.Log("red lock in husband scene openedd");
            isRedLockHusbandOpened = true;
        }
        else
        {
            Debug.Log("please drop the correct key");
        }
    }
}
