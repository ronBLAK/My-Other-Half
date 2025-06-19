using UnityEngine;

public class InstantiateBothCameras : MonoBehaviour
{
    // prefabs of cameras to spawn
    public GameObject cameras;

    // spawned instances of above referenced prefabs are stored here
    private GameObject spawnedCameras;

    public GameObject firstPersonCameraSpawnPoint; // The spawn point for the first person camera

    // the position for the third person camera will be calculated using the first person camera position.

    public void Start()
    {
        spawnedCameras = Instantiate(cameras, firstPersonCameraSpawnPoint.transform.position, Quaternion.identity);
    }
}
