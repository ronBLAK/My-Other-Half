using UnityEngine;
using UnityEngine.UI;

public class InstantiateFPC_CPC : MonoBehaviour
{
    public static InstantiateFPC_CPC instance; // singleton

    private ObjectInPrefabReferencing referencingScript;

    GameObject FpcSpawnPointInPrefab; // the plane in the prefab that will be used to spawn the third and first camera at (its transform will be used to spawn the cameras in scene view (not inside the actual prefab))

    public Camera firstPersonCamera; // reference to the first person camera to be instantiated
    public Camera thirdPersonCamera; // reference to the third person camera to be instantiated

    private GameObject spawnedThirdPersonCamera; // reference to the spawned instance third person camera
    private GameObject spawnedFirstPersonCamera; // reference to the spawned instance first person camera

    // variables to hold the third person camera position and rotation
    private Vector3 savedPositionThirdPersonCamera;
    private Quaternion savedRotationThirdPersonCamera;

    // variables to hold the first person camera position and rotation
    private Vector3 savedPositionFirstPersonCamera;
    private Quaternion savedRotationFirstPersonCamera;

    private float tpcOffset = 0.29568f;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        FpcSpawnPointInPrefab = referencingScript.plane; // get the plane in the prefab that will be used to spawn the third and first camera at
        

        // if no saved position and rotation are found, set the saved position to the plane transform inside player - to spawn camera in positions relative to the player
        savedPositionFirstPersonCamera = new Vector3(
                FpcSpawnPointInPrefab.transform.position.x,
                FpcSpawnPointInPrefab.transform.position.y,
                FpcSpawnPointInPrefab.transform.position.z
            );

            savedRotationFirstPersonCamera = Quaternion.identity; // if no saved rotation is found, set it to identity (default rotation)

            savedPositionThirdPersonCamera = new Vector3(
                FpcSpawnPointInPrefab.transform.position.x,
                FpcSpawnPointInPrefab.transform.position.y,
                FpcSpawnPointInPrefab.transform.position.z - tpcOffset
            );

            savedRotationThirdPersonCamera = Quaternion.identity; // if no saved rotation is found, set it to identity (default rotation)


        // spawn both the cameras in the positions and rotations saved
        spawnedFirstPersonCamera = Instantiate(firstPersonCamera.gameObject, savedPositionFirstPersonCamera, savedRotationFirstPersonCamera);
        spawnedThirdPersonCamera = Instantiate(thirdPersonCamera.gameObject, savedPositionThirdPersonCamera, savedRotationThirdPersonCamera);
    }
}