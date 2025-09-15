using UnityEngine;
using UnityEngine.UI;

public class InstantiateKeysHusbandMaze : MonoBehaviour
{
    public static InstantiateKeysHusbandMaze instance; // Static reference, allows access to this script in other scripts

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

    public ItemDatabase itemDatabase; // reference to the item database
 
    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("SavedHusbandBlueKeyPositionX"))
        {
            // get saved positions for each key
            savedBlueKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyPositionX"),
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyPositionY"),
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyPositionZ")
            );

            savedGreenKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyPositionX"),
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyPositionY"),
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyPositionZ")
            );

            savedRedKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedHusbandRedKeyPositionX"),
                PlayerPrefs.GetFloat("SavedHusbandRedKeyPositionY"),
                PlayerPrefs.GetFloat("SavedHusbandRedKeyPositionZ")
            );

            // get saved rotation for each key
            savedBlueKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyRotationX"),
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyRotationY"),
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedHusbandBlueKeyRotationW")
            );

            savedGreenKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyRotationX"),
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyRotationY"),
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedHusbandGreenKeyRotationW")
            );

            savedRedKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedHusbandRedKeyRotationX"),
                PlayerPrefs.GetFloat("SavedHusbandRedKeyRotationY"),
                PlayerPrefs.GetFloat("SavedHusbandRedKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedHusbandRedKeyRotationW")
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

        InventoryManagerHusband.instance.LoadInventory(itemDatabase); // loads the previously saved inventory at each reload of the scene
            
        // the tracks the existence of each item type in inventory, by passing in the id for each item type into the HasItem bool function
        bool blueKeyInInventory = InventoryManagerHusband.instance.HasItem(0);
        bool greenKeyInInventory = InventoryManagerHusband.instance.HasItem(1);
        bool redKeyInInventory = InventoryManagerHusband.instance.HasItem(2);

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
        if(HusbandEndPortalLogic.hasHusbandEnteredPortal || isRestartButtonPressed || isDontSaveQuitButtonPressed)
        {
            return;
        }

        if(spawnedBlueKey != null)
        {
            savedBlueKeyPosition = spawnedBlueKey.transform.position; // constant position update blue key
            savedBlueKeyRotation = spawnedBlueKey.transform.rotation; // constant rotation update blue key

            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyPositionX", savedBlueKeyPosition.x);
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyPositionY", savedBlueKeyPosition.y);
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyPositionZ", savedBlueKeyPosition.z);

            PlayerPrefs.SetFloat("SavedHusbandBlueKeyRotationX", savedBlueKeyRotation.x);
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyRotationY", savedBlueKeyRotation.y);
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyRotationZ", savedBlueKeyRotation.z);
            PlayerPrefs.SetFloat("SavedHusbandBlueKeyRotationW", savedBlueKeyRotation.w);
            PlayerPrefs.Save();
        }
        if(spawnedGreenKey != null)
        {
            savedGreenKeyPosition = spawnedGreenKey.transform.position; // constant position update green key
            savedGreenKeyRotation = spawnedGreenKey.transform.rotation; // constant rotation update green key
            
            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyPositionX", savedGreenKeyPosition.x);
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyPositionY", savedGreenKeyPosition.y);
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyPositionZ", savedGreenKeyPosition.z);

            PlayerPrefs.SetFloat("SavedHusbandGreenKeyRotationX", savedGreenKeyRotation.x);
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyRotationY", savedGreenKeyRotation.y);
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyRotationZ", savedGreenKeyRotation.z);
            PlayerPrefs.SetFloat("SavedHusbandGreenKeyRotationW", savedGreenKeyRotation.w);
            PlayerPrefs.Save();
        }
        if(spawnedRedKey != null)
        {
            savedRedKeyPosition = spawnedRedKey.transform.position; // constant position update red key
            savedRedKeyRotation = spawnedRedKey.transform.rotation; // constant rotation update red key

            // save the position and rotation on all three and four axes
            PlayerPrefs.SetFloat("SavedHusbandRedKeyPositionX", savedRedKeyPosition.x);
            PlayerPrefs.SetFloat("SavedHusbandRedKeyPositionY", savedRedKeyPosition.y);
            PlayerPrefs.SetFloat("SavedHusbandRedKeyPositionZ", savedRedKeyPosition.z);

            PlayerPrefs.SetFloat("SavedHusbandRedKeyRotationX", savedRedKeyRotation.x);
            PlayerPrefs.SetFloat("SavedHusbandRedKeyRotationY", savedRedKeyRotation.y);
            PlayerPrefs.SetFloat("SavedHusbandRedKeyRotationZ", savedRedKeyRotation.z);
            PlayerPrefs.SetFloat("SavedHusbandRedKeyRotationW", savedRedKeyRotation.w);
            PlayerPrefs.Save();
        }
    }
}
