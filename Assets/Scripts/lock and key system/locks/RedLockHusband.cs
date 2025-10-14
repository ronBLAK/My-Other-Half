using UnityEngine;

public class RedLockHusband : MonoBehaviour
{
    public static RedLockHusband instance;

    public GameObject keyGate; // reference to the obejct that should block the wrong key from going through
    private MeshCollider gateMeshCollider;

    public bool isRedLockHusbandOpened = false; // flag to check if the red lock has been opened by the husband

    public Animator shackleAnimator; // reference to the animator of the shackle

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("IsRedLockHusbandOpened"))
        {
            isRedLockHusbandOpened = PlayerPrefs.GetInt("IsRedLockHusbandOpened", 0) == 1;
        }
        else
        {
            isRedLockHusbandOpened = false;
        }
    }

    public void Update()
    {
        if(isRedLockHusbandOpened)
        {
            shackleAnimator.SetBool("IsRedLockOpenedHusband", true);
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("red key husband"))
        {
            Debug.Log("red lock in husband scene openedd");
            isRedLockHusbandOpened = true;

            // save the current state of the lock (after it has been opened). this will revert back to false when reset, as the game is quit without saving or restarted
            PlayerPrefs.SetInt("IsRedLockHusbandOpened", isRedLockHusbandOpened ? 1 : 0);
            PlayerPrefs.Save();

            // the mesh collider of the key gate is by default enabled, so we need to disable it to allow the key to pass through
            gateMeshCollider.enabled = false;

            shackleAnimator.SetBool("IsRedLockOpenedHusband", true);
        }
        else
        {
            Debug.Log("please drop the correct key");

            // set mesh collider of gate to true just in case it was previously disabled
            gateMeshCollider.enabled = true;

            if (other.attachedRigidbody != null)
            {
                // Nudge it upwards slightly to re-check collisions
                other.attachedRigidbody.position += Vector3.up * 0.1f;
            }
        }
    }
}
