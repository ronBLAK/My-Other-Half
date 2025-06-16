using UnityEngine;

public class ObjectInPrefabReferencing : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonCameraInstantiationPoint; // reference to the location where the FPS camera has to spawn (is used to calculate the position of the TP camera)

    public GameObject plane => firstPersonCameraInstantiationPoint;
}
