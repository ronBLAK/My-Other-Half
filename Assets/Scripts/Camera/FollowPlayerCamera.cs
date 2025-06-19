using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public MouseLook mouseLook; // Reference to the MouseLook script

    public Transform tpc; // reference to the third person controller
    public Transform fpc; // reference to the first person controller

    [Header("Target to follow")]
    private Transform playerTransform;

    [Header("Offset from the player")]
    private Vector3 tpcOffset;
    private Vector3 fpcOffset;

    public void Start()
    {
        playerTransform = Husband.instance.GetSpawnedPlayer().transform;

        fpcOffset = new Vector3(0f, 0.75f, playerTransform.position.z - fpc.position.z);
        tpcOffset = new Vector3(0f, 0.63f, playerTransform.position.z - tpc.position.z);
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Only follow position, no rotation
            tpc.position = playerTransform.position + tpcOffset;
            fpc.position = playerTransform.position + fpcOffset;
        }
    }
}