using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    public GameObject player;
    private GameObject spawnedPlayer;

    // variables to hold the player 's position and rotation
    private Vector3 savedPos;
    private Quaternion savedRot;

    [SerializeField]
    private bool deletePlayerPrefs;

    void Start()
    {
        if(PlayerPrefs.HasKey("SavedPosX"))
        {
            savedPos = new Vector3(
                PlayerPrefs.GetFloat("SavedPosX"),
                PlayerPrefs.GetFloat("SavedPosY"),
                PlayerPrefs.GetFloat("SavedPosZ")
            );

            savedRot = new Quaternion(
                PlayerPrefs.GetFloat("SavedRotX"),
                PlayerPrefs.GetFloat("SavedRotY"),
                PlayerPrefs.GetFloat("SavedRotZ"),
                PlayerPrefs.GetFloat("SavedRotW")
            );
        } else
        {
            savedPos = Vector3.zero;
            savedRot = Quaternion.identity;
        }

        // spawns the player at the savedPos (0, 0, 0) with a savedRot (quaternion.identity)
        spawnedPlayer = Instantiate(player, savedPos, savedRot);
    }

    void Update()
    {
        savedPos = spawnedPlayer.transform.position;
        savedRot = spawnedPlayer.transform.rotation;

        // save the player position on 3 axes
        PlayerPrefs.SetFloat("SavedPosX", savedPos.x);
        PlayerPrefs.SetFloat("SavedPosY", savedPos.y);
        PlayerPrefs.SetFloat("SavedPosZ", savedPos.z);

        // save the player rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotX", savedRot.x);
        PlayerPrefs.SetFloat("SavedRotY", savedRot.y);
        PlayerPrefs.SetFloat("SavedRotZ", savedRot.z);
        PlayerPrefs.SetFloat("SavedRotW", savedRot.w);
        PlayerPrefs.Save();
    }
}
