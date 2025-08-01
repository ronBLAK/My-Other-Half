using UnityEngine;

public class BlueLockHusband : MonoBehaviour
{
    public bool isBlueLockHusbandOpened = false;

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("blue key husband"))
        {
            Debug.Log("blue lock in husband scene opened");
            isBlueLockHusbandOpened = true;
        }
        else
        {
            Debug.Log("please drop the correct key");
        }
    }
}
