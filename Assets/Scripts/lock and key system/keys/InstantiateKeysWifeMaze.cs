using UnityEngine;
using UnityEngine.UI;

public class InstantiateKeysWifeMaze : MonoBehaviour
{
    public static InstantiateKeysWifeMaze instance; // Static reference, allows access to this script in other scripts

    // references to the gameobjects to be spawned
    [Header("Key Prefabs")]
    public GameObject blueKey;
    public GameObject greenKey;
    public GameObject redKey;

    // reference to the spawned version of each key
    [HideInInspector]
    public GameObject spawnedBlueKey;
    [HideInInspector]
    public GameObject spawnedGreenKey;
    [HideInInspector]
    public GameObject spawnedRedKey;

    // reference to the position of GameObject at which eacg key is to be spawned
    [Header("Key Spawn Position GameObjects")]
    public GameObject blueKeySpawnPoint;
    public GameObject greenKeySpawnPoint;
    public GameObject redKeySpawnPoint;

    // saved positions for each of the keys
    [Header("Saved Position Vectors for Keys")]
    private Vector3 savedBlueKeyPosition;
    private Vector3 savedGreenKeyPosition;
    private Vector3 savedRedKeyPosition;

    // saved rotation for each of the keys
    [Header("Saved Rotation Quaternions for Keys")]
    private Quaternion savedBlueKeyRotation;
    private Quaternion savedGreenKeyRotation;
    private Quaternion savedRedKeyRotation;

    // restart button + isButtonClicked
    [Header("Restart")]
    public Button restartButton;
    private bool isRestartButtonPressed = false;

    // dont save button + isButtonClicked
    [Header("Don't Save")]
    public Button dontSaveQuitButton;
    private bool isDontSaveQuitButtonPressed = false;

    public ItemDatabase itemDatabase;

    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("SavedWifeBlueKeyPositionX"))
        {
            // get saved positions for each key
            savedBlueKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedWifeBlueKeyPositionX"),
                PlayerPrefs.GetFloat("SavedWifeBlueKeyPositionY"),
                PlayerPrefs.GetFloat("SavedWifeBlueKeyPositionZ")
            );

            savedGreenKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedWifeGreenKeyPositionX"),
                PlayerPrefs.GetFloat("SavedWifeGreenKeyPositionY"),
                PlayerPrefs.GetFloat("SavedWifeGreenKeyPositionZ")
            );

            savedRedKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedWifeRedKeyPositionX"),
                PlayerPrefs.GetFloat("SavedWifeRedKeyPositionY"),
                PlayerPrefs.GetFloat("SavedWifeRedKeyPositionZ")
            );

            // get saved rotation for each key
            savedBlueKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedWifeBlueKeyRotationX"),
                PlayerPrefs.GetFloat("SavedWifeBlueKeyRotationY"),
                PlayerPrefs.GetFloat("SavedWifeBlueKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedWifeBlueKeyRotationW")
            );

            savedGreenKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedWifeGreenKeyRotationX"),
                PlayerPrefs.GetFloat("SavedWifeGreenKeyRotationY"),
                PlayerPrefs.GetFloat("SavedWifeGreenKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedWifeGreenKeyRotationW")
            );

            savedRedKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedWifeRedKeyRotationX"),
                PlayerPrefs.GetFloat("SavedWifeRedKeyRotationY"),
                PlayerPrefs.GetFloat("SavedWifeRedKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedWifeRedKeyRotationW")
            );
        } else
        {
            // position
            savedBlueKeyPosition = blueKeySpawnPoint.transform.position;
            savedGreenKeyPosition = greenKeySpawnPoint.transform.position;
            savedRedKeyPosition = redKeySpawnPoint.transform.position;

            // rotation
            savedBlueKeyRotation = Quaternion.identity;
            savedGreenKeyRotation = Quaternion.identity;
            savedRedKeyRotation = Quaternion.identity;
        }

        InventoryManagerWife.instance.LoadInventory(itemDatabase); // loads the previously saved inventory at each reload of the scene
            
        // the tracks the existence of each item type in inventory, by passing in the id for each item type into the HasItem bool function
        bool blueKeyInInventory = InventoryManagerWife.instance.HasItem(0);
        bool greenKeyInInventory = InventoryManagerWife.instance.HasItem(1);
        bool redKeyInInventory = InventoryManagerWife.instance.HasItem(2);

        if (!blueKeyInInventory)
        {
            spawnedBlueKey = Instantiate(blueKey, savedBlueKeyPosition, savedBlueKeyRotation); // spawn the blue key as it is not in inventory currently
        }

        if (!greenKeyInInventory)
        {
            spawnedGreenKey = Instantiate(greenKey, savedGreenKeyPosition, savedGreenKeyRotation); // spawn the green key as it is not in inventory currently
        }

        if (!redKeyInInventory)
        {
            spawnedRedKey = Instantiate(redKey, savedRedKeyPosition, savedRedKeyRotation); // spawn the red key as it is not in inventory currently
        }

        // add a listener for for the restart and dontSaveQuitButton button
        restartButton.onClick.AddListener(() => isRestartButtonPressed = true);
        dontSaveQuitButton.onClick.AddListener(() => isDontSaveQuitButtonPressed = true);
    }

    // Update is called once per frame
    void Update()
    {
        if(HusbandEndPortalLogic.hasHusbandEnteredPortal || isRestartButtonPressed || isDontSaveQuitButtonPressed) //nigga
        {
            return;
        }

        if(spawnedBlueKey != null)
        {
            savedBlueKeyPosition = spawnedBlueKey.transform.position; // constant position update blue key
            savedBlueKeyRotation = spawnedBlueKey.transform.rotation; // constant rotation update blue key

            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedWifeBlueKeyPositionX", savedBlueKeyPosition.x);
            PlayerPrefs.SetFloat("SavedWifeBlueKeyPositionY", savedBlueKeyPosition.y);
            PlayerPrefs.SetFloat("SavedWifeBlueKeyPositionZ", savedBlueKeyPosition.z);

            PlayerPrefs.SetFloat("SavedWifeBlueKeyRotationX", savedBlueKeyRotation.x);
            PlayerPrefs.SetFloat("SavedWifeBlueKeyRotationY", savedBlueKeyRotation.y);
            PlayerPrefs.SetFloat("SavedWifeBlueKeyRotationZ", savedBlueKeyRotation.z);
            PlayerPrefs.SetFloat("SavedWifeBlueKeyRotationW", savedBlueKeyRotation.w);
            PlayerPrefs.Save();
        }
        if(spawnedGreenKey != null)
        {
            savedGreenKeyPosition = spawnedGreenKey.transform.position; // constant position update green key
            savedGreenKeyRotation = spawnedGreenKey.transform.rotation; // constant rotation update green key

            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedWifeGreenKeyPositionX", savedGreenKeyPosition.x);
            PlayerPrefs.SetFloat("SavedWifeGreenKeyPositionY", savedGreenKeyPosition.y);
            PlayerPrefs.SetFloat("SavedWifeGreenKeyPositionZ", savedGreenKeyPosition.z);

            PlayerPrefs.SetFloat("SavedWifeGreenKeyRotationX", savedGreenKeyRotation.x);
            PlayerPrefs.SetFloat("SavedWifeGreenKeyRotationY", savedGreenKeyRotation.y);
            PlayerPrefs.SetFloat("SavedWifeGreenKeyRotationZ", savedGreenKeyRotation.z);
            PlayerPrefs.SetFloat("SavedWifeGreenKeyRotationW", savedGreenKeyRotation.w);
            PlayerPrefs.Save();
        }
        if(spawnedRedKey != null)
        {
            savedRedKeyPosition = spawnedRedKey.transform.position; // constant position update red key
            savedRedKeyRotation = spawnedRedKey.transform.rotation; // constant rotation update red key

            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedWifeRedKeyPositionX", savedRedKeyPosition.x);
            PlayerPrefs.SetFloat("SavedWifeRedKeyPositionY", savedRedKeyPosition.y);
            PlayerPrefs.SetFloat("SavedWifeRedKeyPositionZ", savedRedKeyPosition.z);

            PlayerPrefs.SetFloat("SavedWifeRedKeyRotationX", savedRedKeyRotation.x);
            PlayerPrefs.SetFloat("SavedWifeRedKeyRotationY", savedRedKeyRotation.y);
            PlayerPrefs.SetFloat("SavedWifeRedKeyRotationZ", savedRedKeyRotation.z);
            PlayerPrefs.SetFloat("SavedWifeRedKeyRotationW", savedRedKeyRotation.w);
            PlayerPrefs.Save();
        }
    }
}
