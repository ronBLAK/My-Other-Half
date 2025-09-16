using UnityEngine;
using UnityEngine.UI;

public class InstantiateFirstPersonCameraHusband : MonoBehaviour
{
    public static InstantiateFirstPersonCameraHusband instance;

    // spawned instances of above referenced prefabs are stored here
    private GameObject spawnedFirstPersonCamera;
    public GameObject firstPersonCamera; // reference to the first person camera

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        spawnedFirstPersonCamera = Instantiate(firstPersonCamera, Husband.instance.GetSavedHusbandPosition(), Husband.instance.GetSavedHusbandRotation());
    }

    public GameObject GetSpawnedFirstPersonCamera()
    {
        return spawnedFirstPersonCamera;
    }
}
