using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform playerTransform;

    [Header("Offset from the player")]
    private Vector3 offset;

    public void Start()
    {
        offset = playerTransform.position - transform.position;
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Only follow position, no rotation
            transform.position = playerTransform.position + offset;
        }
    }
}