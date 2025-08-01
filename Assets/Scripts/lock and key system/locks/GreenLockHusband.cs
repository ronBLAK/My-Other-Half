using UnityEngine;

public class GreenLockHusband : MonoBehaviour
{
    public bool isGreenLockHusbandOpened = false;

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key husband"))
        {
            Debug.Log("green lock in husband scene opened");
            isGreenLockHusbandOpened = true;
        }
        else
        {
            Debug.Log("please drop the correct key");
        }
    }
}
