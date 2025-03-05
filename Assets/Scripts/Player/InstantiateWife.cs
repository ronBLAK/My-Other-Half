using UnityEngine;

public class InstantiateWife : MonoBehaviour
{
    public GameObject player;
    private GameObject spawnedPlayer;

    // variables to hold the player 's position and rotation
    private Vector3 savedPositionWife;
    private Quaternion savedRotationWife;

    void Start()
    {
        if(PlayerPrefs.HasKey("SavedPosXWife"))
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
        } else
        {
            savedPositionWife = Vector3.zero;
            savedRotationWife = Quaternion.identity;
        }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPositionWife, savedRotationWife);
    }

    void Update()
    {
        // skips saving player resaving wife's position after its been deleted (prevents the wife from being spawned at same position as the end of the game)
        if(WifeEndPortalLogic.hasWifeEnteredPortal)
        {
            return;
        }
        
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
}
