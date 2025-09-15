using UnityEngine;

public class FollowHusbandCamera : MonoBehaviour
{
    private Transform firstPersonCamera; // reference to the first person camera
    private Transform playerTransform; // reference to the player's transform
    private Transform firstPersonCameraHolder; // reference to the first person camera holder
    private Vector3 fpcOffset;

    public void Start()
    {
        playerTransform = Husband.instance.GetSpawnedPlayer().transform; // get the player's transform

        // get the first person camera and holder, and finds the first person camera from its parent holder
        firstPersonCameraHolder = InstantiateFirstPersonCameraHusband.instance.GetSpawnedFirstPersonCamera().transform;
        firstPersonCamera = firstPersonCameraHolder.Find("FirstPersonCamera");

        fpcOffset = new Vector3(0f, 0.75f, 0f); // sets the off
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // first person camera follows the player
            firstPersonCamera.position = playerTransform.position + fpcOffset;
        }
    }
}
