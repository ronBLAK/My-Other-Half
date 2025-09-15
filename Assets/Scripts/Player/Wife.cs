using UnityEngine;
using UnityEngine.UI;

public class Wife : MonoBehaviour
{
    public static Wife instance; // makes this class a singleton

    public GameObject player; // reference to the player
    private GameObject spawnedPlayer; // the instance of the player that is spawned during runtime

    // variables to hold the player 's position and rotation
    private Vector3 savedPositionWife;
    private Quaternion savedRotationWife;

    // holds the restart button
    public Button restartButton;
    private bool isRestartButtonPressed = false;

    private float distanceInFront = 0.25f;

    // holds don't save and quit button
    public Button dontSaveQuitButton;
    private bool isDontSaveQuitButtonPressed = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // gets the saved wife information (if there is one), to be passed into the instantiate method
        if (PlayerPrefs.HasKey("SavedPosXWife"))
        {
            savedPositionWife = new Vector3(
                PlayerPrefs.GetFloat("SavedPosXWife"),
                PlayerPrefs.GetFloat("SavedPosYWife"),
                PlayerPrefs.GetFloat("SavedPosZWife")
            );

            savedRotationWife = new Quaternion(
                PlayerPrefs.GetFloat("SavedRotXWife"),
                PlayerPrefs.GetFloat("SavedRotYWife"),
                PlayerPrefs.GetFloat("SavedRotZWife"),
                PlayerPrefs.GetFloat("SavedRotWWife")
            );
        }
        else
        {
            savedPositionWife = Vector3.zero;
            savedRotationWife = Quaternion.identity;
        }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPositionWife, savedRotationWife);

        // adds a listener to the restart button
        restartButton.onClick.AddListener(() => isRestartButtonPressed = true);
        dontSaveQuitButton.onClick.AddListener(() => isDontSaveQuitButtonPressed = true);
    }

    void Update()
    {
        // skips saving player resaving wife's position after its been deleted (prevents the wife from being spawned at same position as the end of the game)
        if (WifeEndPortalLogic.hasWifeEnteredPortal || isRestartButtonPressed || isDontSaveQuitButtonPressed)
        {
            return;
        }

        // constantly updates the saved position and rotation of the wife
        savedPositionWife = spawnedPlayer.transform.position;
        savedRotationWife = spawnedPlayer.transform.rotation;

        // save the player position on 3 axes
        PlayerPrefs.SetFloat("SavedPosXWife", savedPositionWife.x);
        PlayerPrefs.SetFloat("SavedPosYWife", savedPositionWife.y);
        PlayerPrefs.SetFloat("SavedPosZWife", savedPositionWife.z);

        // save the player rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotXWife", savedRotationWife.x);
        PlayerPrefs.SetFloat("SavedRotYWife", savedRotationWife.y);
        PlayerPrefs.SetFloat("SavedRotZWife", savedRotationWife.z);
        PlayerPrefs.SetFloat("SavedRotWWife", savedRotationWife.w);
        PlayerPrefs.Save();
    }

    public GameObject GetSpawnedPlayer()
    {
        return spawnedPlayer;
    }

    public Vector3 GetSavedWifePosition()
    {
        return savedPositionWife;
    }

    public Quaternion GetSavedWifeRotation()
    {
        return savedRotationWife;
    }

    // methods to handle dropping items out of the inventory (not used in this script), but used in the actual dropping logic (when the items are removed from the inventory). these methods are just declared in the player husband class because they are attributes of the player (drop logic)
    public void DropBlueKey(GameObject blueKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront; // calculates the position where the key has to be dropped, relative to the player

        InstantiateKeysWifeMaze.instance.spawnedBlueKey = Instantiate(blueKey, dropPosition, Quaternion.identity); // spawns the game object passed into the method at the calculated drop position, and sets it equal to the initial spawnedBlueKey
    }

    public void DropGreenKey(GameObject greenKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront; // calculates the position where the key has to be dropped, relative to the player

        InstantiateKeysWifeMaze.instance.spawnedGreenKey = Instantiate(greenKey, dropPosition, Quaternion.identity); // spawns the game object passed into the method at the calculated drop position, and sets it equal to the inital spawnedGreenKey
    }

    public void DropRedKey(GameObject redKey)
    {
        Vector3 dropPosition = spawnedPlayer.transform.position + spawnedPlayer.transform.forward * distanceInFront;

        InstantiateKeysWifeMaze.instance.spawnedRedKey = Instantiate(redKey, dropPosition, Quaternion.identity);
    }
}
