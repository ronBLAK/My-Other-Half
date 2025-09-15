using UnityEngine;
using UnityEngine.UI;

public class InstantiateFirstPersonCameraWife : MonoBehaviour
{
    public static InstantiateFirstPersonCameraWife instance;

    // spawned instances of above referenced prefabs are stored here
    private GameObject spawnedFirstPersonCamera;
    public GameObject firstPersonCamera; // reference to the first person camera

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        spawnedFirstPersonCamera = Instantiate(firstPersonCamera, Wife.instance.GetSavedWifePosition(), Wife.instance.GetSavedWifeRotation());
    }

    public GameObject GetSpawnedFirstPersonCamera()
    {
        return spawnedFirstPersonCamera;
    }
}
