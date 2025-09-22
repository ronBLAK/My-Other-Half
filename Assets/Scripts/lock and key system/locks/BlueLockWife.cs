using UnityEngine;

public class BlueLockWife : MonoBehaviour
{
    public static BlueLockWife instance;

    public GameObject keyGate;
    private MeshCollider gateMeshCollider;

    public bool isBlueLockWifeOpened = false;

    public Animator shackleAnimator; // reference to the animator of the shackle

    public void Awake()
    {
        instance = this;
        gateMeshCollider = keyGate.GetComponent<MeshCollider>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("IsBlueLockOpenedWife"))
        {
            isBlueLockWifeOpened = PlayerPrefs.GetInt("IsBlueLockOpenedWife", 0) == 1;
        }
        else
        {
            isBlueLockWifeOpened = false;
        }
    }

    public void Update()
    {
        if(isBlueLockWifeOpened)
        {
            shackleAnimator.SetBool("IsBlueLockOpenedWife", true);
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the key dropped is the blue key, to open blue lock, so that nlue lock can only be opened with the blue key
        if (other.CompareTag("blue key wife"))
        {
            Debug.Log("blue lock in wife scene openedd");
            isBlueLockWifeOpened = true;

            PlayerPrefs.SetInt("IsBlueLockOpenedWife", isBlueLockWifeOpened ? 1 : 0);
            PlayerPrefs.Save();

            gateMeshCollider.enabled = false;

            shackleAnimator.SetBool("IsBlueLockOpenedWife", true);
        }
        else
        {
            Debug.Log("please drop the correct key");

            gateMeshCollider.enabled = true;
        }
    }
}