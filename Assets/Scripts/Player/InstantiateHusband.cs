using UnityEngine;

public class InstantiateHusband : MonoBehaviour
{
    public GameObject player;
    private GameObject spawnedPlayer;

    // variables to hold the player 's position and rotation
    private Vector3 savedPositionHusband;
    private Quaternion savedRotationWife;

    void Start()
    {
        // if(PlayerPrefs.HasKey("SavedPosXHusband"))
        // {
        //     savedPositionHusband = new Vector3(
        //         PlayerPrefs.GetFloat("SavedPosXHusband"),
        //         PlayerPrefs.GetFloat("SavedPosYHusband"),
        //         PlayerPrefs.GetFloat("SavedPosZHusband")
        //     );

        //     savedRotationWife = new Quaternion(
        //         PlayerPrefs.GetFloat("SavedRotXHusband"),
        //         PlayerPrefs.GetFloat("SavedRotYHusband"),
        //         PlayerPrefs.GetFloat("SavedRotZHusband"),
        //         PlayerPrefs.GetFloat("SavedRotWHusband")
        //     );
        // } else
        // {
            savedPositionHusband = Vector3.zero;
            savedRotationWife = Quaternion.identity;
        // }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPositionHusband, savedRotationWife);
    }

    void Update()
    {
        savedPositionHusband = spawnedPlayer.transform.position;
        savedRotationWife = spawnedPlayer.transform.rotation;

        // save the player position on 3 axes
        PlayerPrefs.SetFloat("SavedPosXHusband", savedPositionHusband.x);
        PlayerPrefs.SetFloat("SavedPosYHusband", savedPositionHusband.y);
        PlayerPrefs.SetFloat("SavedPosZHusband", savedPositionHusband.z);

        // save the player rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotXHusband", savedRotationWife.x);
        PlayerPrefs.SetFloat("SavedRotYHusband", savedRotationWife.y);
        PlayerPrefs.SetFloat("SavedRotZHusband", savedRotationWife.z);
        PlayerPrefs.SetFloat("SavedRotWHusband", savedRotationWife.w);
        PlayerPrefs.Save();
    }
}
