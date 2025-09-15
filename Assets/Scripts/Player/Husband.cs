using UnityEngine;
using UnityEngine.UI;

public class Husband : MonoBehaviour
{
    public static Husband instance; // makes this class a singleton

    public GameObject player; // reference to the player object
    private GameObject spawnedPlayer; // the instance of the player that is spawned during runtime

    // variables to hold the player 's position and rotation
    private Vector3 savedPositionHusband;
    private Quaternion savedRotationHusband;

    // holds the restart button
    public Button restartButton;
    private bool isRestartButtonPressed = false;

    // holds don't save and quit button
    public Button dontSaveQuitButton;
    private bool isDontSaveQuitButtonPressed = false;

    private float distanceInFront = 0.25f; // this is the distance the dropped key will spawn from the player

    public GameObject SpawnedPlayer => spawnedPlayer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // gets the saved husband information (if there is one), to be passed into the instaniate husband method
        if (PlayerPrefs.HasKey("SavedPosXHusband"))
        {
            savedPositionHusband = new Vector3(
                PlayerPrefs.GetFloat("SavedPosXHusband"),
                PlayerPrefs.GetFloat("SavedPosYHusband"),
                PlayerPrefs.GetFloat("SavedPosZHusband")
            );

            savedRotationHusband = new Quaternion(
                PlayerPrefs.GetFloat("SavedRotXHusband"),
                PlayerPrefs.GetFloat("SavedRotYHusband"),
                PlayerPrefs.GetFloat("SavedRotZHusband"),
                PlayerPrefs.GetFloat("SavedRotWHusband")
            );
        }
        else
        {
            savedPositionHusband = Vector3.zero;
            savedRotationHusband = Quaternion.identity;
        }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPositionHusband, savedRotationHusband);

        // add a listener for for the restart and dontSaveQuitButton button
        restartButton.onClick.AddListener(() => isRestartButtonPressed = true);
        dontSaveQuitButton.onClick.AddListener(() => isDontSaveQuitButtonPressed = true);
    }

    void Update()
    {
        // skips saving player resaving husband's position after its been deleted (prevents the husband from being spawned at same position as the end of the game)
        if (HusbandEndPortalLogic.hasHusbandEnteredPortal || isRestartButtonPressed || isDontSaveQuitButtonPressed)
        {
            return;
        }

        // constantly updates the saved postion and rotation of the husband
        savedPositionHusband = spawnedPlayer.transform.position;
        savedRotationHusband = spawnedPlayer.transform.rotation;

        // save the player position on 3 axes
        PlayerPrefs.SetFloat("SavedPosXHusband", savedPositionHusband.x);
        PlayerPrefs.SetFloat("SavedPosYHusband", savedPositionHusband.y);
        PlayerPrefs.SetFloat("SavedPosZHusband", savedPositionHusband.z);

        // save the player rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotXHusband", savedRotationHusband.x);
        PlayerPrefs.SetFloat("SavedRotYHusband", savedRotationHusband.y);
        PlayerPrefs.SetFloat("SavedRotZHusband", savedRotationHusband.z);
        PlayerPrefs.SetFloat("SavedRotWHusband", savedRotationHusband.w);
        PlayerPrefs.Save();
    }

    // getter methods
    public GameObject GetSpawnedPlayer()
    {
        return spawnedPlayer;
    }

    public Vector3 GetSavedHusbandPosition()
    {
        return savedPositionHusband;
    }

    public Quaternion GetSavedHusbandRotation()
    {
        return savedRotationHusband;
    }

    // methods to handle dropping items out of the inventory (not used in this script), but used in the actual dropping logic (when the items are removed from the inventory). these methods are just declared in the player husband class because they are attributes of the player (drop logic)
    public void DropBlueKey(GameObject blueKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront; // calculates the position where the key has to be dropped, relative to the player

        InstantiateKeysHusbandMaze.instance.spawnedBlueKey = Instantiate(blueKey, dropPosition, Quaternion.identity); // spawns the game object passed into the method at the calculated drop position, and sets it equal to the initial spawnedBlueKey
    }

    public void DropGreenKey(GameObject greenKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront; // calculates the position where the key has to be dropped, relative to the player

        InstantiateKeysHusbandMaze.instance.spawnedGreenKey = Instantiate(greenKey, dropPosition, Quaternion.identity); // spawns the game object passed into the method at the calculated drop position, and sets it equal to the inital spawnedGreenKey
    }

    public void DropRedKey(GameObject redKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront;

        InstantiateKeysHusbandMaze.instance.spawnedRedKey = Instantiate(redKey, dropPosition, Quaternion.identity);
    }
}
