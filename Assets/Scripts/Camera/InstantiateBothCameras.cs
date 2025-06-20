using UnityEngine;

public class InstantiateFirstPersonCamera : MonoBehaviour
{
    public static InstantiateFirstPersonCamera instance;

    // prefabs of cameras to spawn
    public GameObject firstPersonCamera;

    // spawned instances of above referenced prefabs are stored here
    private GameObject spawnedFirstPersonCamera;

    public GameObject firstPersonCameraSpawnPoint; // The spawn point for the first person camera

    // the position for the third person camera will be calculated using the first person camera position.

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        spawnedFirstPersonCamera = Instantiate(firstPersonCamera, firstPersonCameraSpawnPoint.transform.position, Quaternion.identity);
    }

    public GameObject GetSpawnedFirstPersonCamera()
    {
        return spawnedFirstPersonCamera;
    }
}
