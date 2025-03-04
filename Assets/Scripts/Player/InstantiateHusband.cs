using UnityEngine;

public class InstantiateHusband : MonoBehaviour
{
    public GameObject player;
    private GameObject spawnedPlayer;

    // variables to hold the player 's position and rotation
    private Vector3 savedPositionHusband;
    private Quaternion savedRotationHusband;

    void Start()
    {
        if(PlayerPrefs.HasKey("SavedPosXHusband"))
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
        } else
        {
            savedPositionHusband = Vector3.zero;
            savedRotationHusband = Quaternion.identity;
        }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPositionHusband, savedRotationHusband);
    }

    void Update()
    {
        // skips saving player resaving husband's position after its been deleted (prevents the husband from being spawned at same position as the end of the game)
        if(!PlayerPrefs.HasKey("SavedPosXHusband"))
        {
            Debug.Log("skipping save as values cleared");
            return;
        }

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
}
