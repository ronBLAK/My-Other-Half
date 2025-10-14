using UnityEngine;

public class GreenLockWife : MonoBehaviour
{
    public static GreenLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isGreenLockWifeOpened = false;

    public Animator shackleAnimator; // reference to the animator of the shackle

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("IsGreenLockOpenedWife"))
        {
            isGreenLockWifeOpened = PlayerPrefs.GetInt("IsGreenLockOpenedWife", 0) == 1;
        }
        else
        {
            isGreenLockWifeOpened = false;
        }
    }

    public void Update()
    {
        if(isGreenLockWifeOpened)
        {
            shackleAnimator.SetBool("IsGreenLockOpenedWife", true);
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key wife"))
        {
            Debug.Log("green lock in wife scene openedd");
            isGreenLockWifeOpened = true;

            PlayerPrefs.SetInt("IsGreenLockOpenedWife", isGreenLockWifeOpened ? 1 : 0);
            PlayerPrefs.Save();

            gateMeshCollider.enabled = false;

            shackleAnimator.SetBool("IsGreenLockOpenedWife", true);
        }
        else
        {
            Debug.Log("please drop the correct key");
            
            gateMeshCollider.enabled = true;

            if (other.attachedRigidbody != null)
            {
                // Nudge it upwards slightly to re-check collisions
                other.attachedRigidbody.position += Vector3.up * 0.1f;
            }
        }
    }
}
