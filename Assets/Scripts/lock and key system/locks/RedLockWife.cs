using UnityEngine;

public class RedLockWife : MonoBehaviour
{
    public static RedLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isRedLockWifeOpened = false;

    public Animator shackleAnimator; // reference to the animator of the shackle

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("IsRedLockOpenedWife"))
        {
            isRedLockWifeOpened = PlayerPrefs.GetInt("IsRedLockOpenedWife", 0) == 1;
        }
        else
        {
            isRedLockWifeOpened = false;
        }
    }

    public void Update()
    {
        if(isRedLockWifeOpened)
        {
            shackleAnimator.SetBool("IsRedLockOpenedWife", true);
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("red key wife"))
        {
            Debug.Log("red lock in wife scene openedd");
            isRedLockWifeOpened = true;

            PlayerPrefs.SetInt("IsRedLockOpenedWife", isRedLockWifeOpened ? 1 : 0);
            PlayerPrefs.Save();

            gateMeshCollider.enabled = false;

            shackleAnimator.SetBool("IsRedLockOpenedWife", true);
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
