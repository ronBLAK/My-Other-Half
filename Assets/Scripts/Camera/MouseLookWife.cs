using UnityEngine;
using UnityEngine.UI;

public class MouseLookWife : MonoBehaviour
{
    private Transform playerBody; // Reference to the player's body object to rotate horizontally
    private Transform thirdPersonCamera; // Reference to the third person camera
    private Transform firstPersonCameraHolder; // reference to the transform of the gameObject that holds both the cameras
    private Transform firstPersonCamera; // Reference to the first person camera
    
    public float sensitivity = 100f; // Mouse sensitivity for camera movement
    public float clampAngle = 80f; // Maximum angle to look up and down

    private float verticalRotation = 0f; // Current vertical rotation angle
    private bool isFirstPerson = false; // Flag to track if the camera is in first-person mode

    [SerializeField] private GameObject crosshair; // Reference to the crosshair object

    void Start()
    {
        // setting of third person camera and its holder (playerBody)
        playerBody = Wife.instance.GetSpawnedPlayer().transform;
        thirdPersonCamera = playerBody.transform.Find("ThirdPersonCamera");

        // setting of first person camera and its holder (firstPersonCameraHolder)
        firstPersonCameraHolder = InstantiateFirstPersonCameraWife.instance.GetSpawnedFirstPersonCamera().transform;
        firstPersonCamera = firstPersonCameraHolder.transform.Find("FirstPersonCamera");

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set the initial camera mode
        SetCamera(isFirstPerson);
    }

    void Update()
    {
        // Toggle camera mode when the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFirstPerson = !isFirstPerson;
            SetCamera(isFirstPerson);
        }

        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the camera and player when in first-person mode
        playerBody.Rotate(Vector3.up * mouseX);
        firstPersonCameraHolder.rotation = Wife.instance.GetSavedWifeRotation();

        // Update and clamp the vertical rotation of the camera
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        // Apply the vertical rotation to the camera's local rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    // Method to switch between first-person and third-person camera modes
    private void SetCamera(bool isFirstPerson)
    {
        if (isFirstPerson)
        {
            // Enable the first-person camera and disable the third-person camera
            thirdPersonCamera.gameObject.SetActive(false);
            firstPersonCamera.gameObject.SetActive(true);
            crosshair.SetActive(true); // Show the crosshair in first-person mode
        }
        else
        {
            // Enable the third-person camera and disable the first-person camera
            thirdPersonCamera.gameObject.SetActive(true);
            firstPersonCamera.gameObject.SetActive(false);
            crosshair.SetActive(false); // Hide the crosshair in third-person mode
        }
    }
}
