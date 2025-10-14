using UnityEngine;

public class GreenLockHusband : MonoBehaviour
{
    public static GreenLockHusband instance;

    public GameObject keyGate; // reference to the obejct that should block the wrong key from going through
    private MeshCollider gateMeshCollider;

    public bool isGreenLockHusbandOpened = false; // flag to check if the green lock has been opened by the husband

    public Animator shackleAnimator; // reference to the animator of the shackle

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("IsGreenLockHusbandOpened"))
        {
            isGreenLockHusbandOpened = PlayerPrefs.GetInt("IsGreenLockHusbandOpened", 0) == 1;
        }
        else
        {
            isGreenLockHusbandOpened = false;
        }
    }

    public void Update()
    {
        if(isGreenLockHusbandOpened)
        {
            shackleAnimator.SetBool("IsGreenLockOpenedHusband", true);
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("green key husband"))
        {
            Debug.Log("green lock in husband scene opened");
            isGreenLockHusbandOpened = true;

            // save the current state of the lock (after it has been opened). this will revert back to false when reset, as the game is quit without saving or restarted
            PlayerPrefs.SetInt("IsGreenLockHusbandOpened", isGreenLockHusbandOpened ? 1 : 0);
            PlayerPrefs.Save();

            // the mesh collider of the key gate is by default enabled, so we need to disable it to allow the key to pass through
            gateMeshCollider.enabled = false;

            shackleAnimator.SetBool("IsGreenLockOpenedHusband", true);
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
