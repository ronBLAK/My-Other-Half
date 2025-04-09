using UnityEngine;
using UnityEngine.UI;

public class InstantiateKeys : MonoBehaviour
{
    // references to the gameobjects to be spawned
    [Header("Key Prefabs")]
    public GameObject blueKey;
    public GameObject greenKey;
    public GameObject redKey;

    // reference to the spawned version of each key
    private GameObject spawnedBlueKey;
    private GameObject spawnedGreenKey;
    private GameObject spawnedRedKey;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.HasKey("SavedBlueKeyPositionX"))
        {
            // get saved positions for each key
            savedBlueKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedBlueKeyPositionX"),
                PlayerPrefs.GetFloat("SavedBlueKeyPositionY"),
                PlayerPrefs.GetFloat("SavedBlueKeyPositionZ")
            );

            savedGreenKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedGreenKeyPositionX"),
                PlayerPrefs.GetFloat("SavedGreenKeyPositionY"),
                PlayerPrefs.GetFloat("SavedGreenKeyPositionZ")
            );

            savedRedKeyPosition = new Vector3(
                PlayerPrefs.GetFloat("SavedRedKeyPositionX"),
                PlayerPrefs.GetFloat("SavedRedKeyPositionY"),
                PlayerPrefs.GetFloat("SavedRedKeyPositionZ")
            );

            // get saved rotation for each key
            savedBlueKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedBlueKeyRotationX"),
                PlayerPrefs.GetFloat("SavedBlueKeyRotationY"),
                PlayerPrefs.GetFloat("SavedBlueKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedBlueKeyRotationW")
            );

            savedGreenKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedGreenKeyRotationX"),
                PlayerPrefs.GetFloat("SavedGreenKeyRotationY"),
                PlayerPrefs.GetFloat("SavedGreenKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedGreenKeyRotationW")
            );

            savedRedKeyRotation = new Quaternion(
                PlayerPrefs.GetFloat("SavedRedKeyRotationX"),
                PlayerPrefs.GetFloat("SavedRedKeyRotationY"),
                PlayerPrefs.GetFloat("SavedRedKeyRotationZ"),
                PlayerPrefs.GetFloat("SavedRedKeyRotationW")
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

        spawnedBlueKey = Instantiate(blueKey, savedBlueKeyPosition, savedBlueKeyRotation);
        spawnedGreenKey = Instantiate(greenKey, savedGreenKeyPosition, savedGreenKeyRotation);
        spawnedRedKey = Instantiate(redKey, savedRedKeyPosition, savedRedKeyRotation);

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

        // constant position update
        savedBlueKeyPosition = spawnedBlueKey.transform.position;
        savedGreenKeyPosition = spawnedGreenKey.transform.position;
        savedRedKeyPosition = spawnedRedKey.transform.position;

        // constant rotation update
        savedBlueKeyRotation = spawnedBlueKey.transform.rotation;
        savedGreenKeyRotation = spawnedGreenKey.transform.rotation;
        savedRedKeyRotation = spawnedRedKey.transform.rotation;

        // save the position and rotation on all three and four axes
        // blue key
        PlayerPrefs.SetFloat("SavedBlueKeyPositionX", savedBlueKeyPosition.x);
        PlayerPrefs.SetFloat("SavedBlueKeyPositionY", savedBlueKeyPosition.y);
        PlayerPrefs.SetFloat("SavedBlueKeyPositionZ", savedBlueKeyPosition.z);

        PlayerPrefs.SetFloat("SavedBlueKeyRotationX", savedBlueKeyRotation.x);
        PlayerPrefs.SetFloat("SavedBlueKeyRotationY", savedBlueKeyRotation.y);
        PlayerPrefs.SetFloat("SavedBlueKeyRotationZ", savedBlueKeyRotation.z);
        PlayerPrefs.SetFloat("SavedBlueKeyRotationW", savedBlueKeyRotation.w);
        PlayerPrefs.Save();

        // green key
        PlayerPrefs.SetFloat("SavedGreenKeyPositionX", savedGreenKeyPosition.x);
        PlayerPrefs.SetFloat("SavedGreenKeyPositionY", savedGreenKeyPosition.y);
        PlayerPrefs.SetFloat("SavedGreenKeyPositionZ", savedGreenKeyPosition.z);

        PlayerPrefs.SetFloat("SavedGreenKeyRotationX", savedGreenKeyRotation.x);
        PlayerPrefs.SetFloat("SavedGreenKeyRotationY", savedGreenKeyRotation.y);
        PlayerPrefs.SetFloat("SavedGreenKeyRotationZ", savedGreenKeyRotation.z);
        PlayerPrefs.SetFloat("SavedGreenKeyRotationW", savedGreenKeyRotation.w);
        PlayerPrefs.Save();

        // red key
        PlayerPrefs.SetFloat("SavedRedKeyPositionX", savedRedKeyPosition.x);
        PlayerPrefs.SetFloat("SavedRedKeyPositionY", savedRedKeyPosition.y);
        PlayerPrefs.SetFloat("SavedRedKeyPositionZ", savedRedKeyPosition.z);

        PlayerPrefs.SetFloat("SavedRedKeyRotationX", savedRedKeyRotation.x);
        PlayerPrefs.SetFloat("SavedRedKeyRotationY", savedRedKeyRotation.y);
        PlayerPrefs.SetFloat("SavedRedKeyRotationZ", savedRedKeyRotation.z);
        PlayerPrefs.SetFloat("SavedRedKeyRotationW", savedRedKeyRotation.w);
        PlayerPrefs.Save();
    }
}
