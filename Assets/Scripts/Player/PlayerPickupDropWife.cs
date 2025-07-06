
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDropWife : MonoBehaviour
{
    private Transform playerCameraTransform; // Reference to the player's camera for raycasting
    private Transform playerCameraHolder; // reference to the GameObject holding the
    [SerializeField] private LayerMask pickupLayerMask; // Layer mask to filter which objects can be picked up
    [SerializeField] private Transform objectGrabPointTransform; // Point where the object will be held

    private ObjectGrabbable objectGrabbable; // Reference to the currently grabbable object

    private void Start()
    {
        playerCameraHolder = InstantiateFirstPersonCameraWife.instance.GetSpawnedFirstPersonCamera().transform;
        playerCameraTransform = playerCameraHolder.Find("FirstPersonCamera");
    }

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            if (objectGrabbable == null)
            {
                // Not carrying an object, attempt to grab an object
                float pickupDistance = 2f; // Maximum distance to check for pickup

                // Perform a raycast from the camera to check if it hits a grabbable object
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    // Check if the hit object has the ObjectGrabbable component
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        // Grab the object and attach it to the grab point
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log("Picked up: " + objectGrabbable);
                    }
                }
            }
            else
            {
                // Currently carrying an object, drop it
                objectGrabbable.Drop();
                objectGrabbable = null; // Clear the reference after dropping
                Debug.Log("Object has been dropped (gameObject no longer held by player), or has not been picked up in the first place (nothing happens)");
            }
        }
    }
}
