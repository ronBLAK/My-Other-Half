using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f; // Player walking speed
    public float runSpeed = 6f;  // Player running speed
    private Animator mainCharAnimControl; // Reference to the Animator component for controlling animations
    public Camera playerCamera; // Reference to the Camera to calculate movement relative to it
    private float currentSpeed; // Variable to store the current speed (walk or run)

    // Reference to the Ground check script for detecting if the player is on the ground
    private GroundCheck groundDetector;

    public CharacterController playerCharacterController; // Reference to the CharacterController component

    void Start()
    {
        // Initialize the Animator and set initial speed
        mainCharAnimControl = GetComponent<Animator>();
        currentSpeed = walkSpeed;

        // Get the GroundCheck component attached to the same GameObject
        groundDetector = GetComponent<GroundCheck>();
    }

    void Update()
    {
        // Clamp speed values to prevent excessive values
        if (walkSpeed >= 6)
        {
            walkSpeed = 6;
        }
        if (runSpeed >= 7)
        {
            runSpeed = 7;
        }

        // Retrieve input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get forward and right vectors based on the camera orientation
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // Project forward and right vectors onto the horizontal plane (y = 0) and normalize
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction relative to the camera
        Vector3 movementDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // Check if the Shift key is pressed to toggle between walk and run speeds
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            currentSpeed = (currentSpeed == walkSpeed) ? runSpeed : walkSpeed;
            mainCharAnimControl.SetBool("IsRunning", currentSpeed == runSpeed);
        }

        // Check if the Shift key is released
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            mainCharAnimControl.SetBool("IsRunning", false);
            mainCharAnimControl.SetBool("IsWalking", true);
            currentSpeed = walkSpeed;
        }

        // allows the player to look at the direction they are moving in, and adds a cap to how much they can turn when s/arrow down keys are pressed
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            // Detect if the back key (S or down arrow) is the only input
            bool movingBackwardOnly = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

            if (movingBackwardOnly)
            {
                // Calculate the angle between current forward and target
                float angle = Quaternion.Angle(transform.rotation, targetRotation);

                // Limit rotation if angle is greater than 180 (it shouldn't be, but we keep this just in case)
                if (angle > 180f)
                {
                    angle = 180f;
                }

                // Clamp rotation to at most 180 degrees by rotating more slowly
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Mathf.Min(angle, 180f) * Time.deltaTime * 2f);
            }
            else
            {
                // Normal smooth turning
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }

        // Calculate and apply movement based on input and current speed
        Vector3 movement = movementDirection * currentSpeed * Time.deltaTime;
        playerCharacterController.Move(movement);

        // Smooth the movement to reduce snapping
        Vector3 targetPosition = transform.position + movement;
        playerCharacterController.Move(targetPosition - transform.position);

        // Set animation parameters based on movement
        mainCharAnimControl.SetBool("IsWalking", movement.magnitude > 0);

        // Check if the player is grounded using the GroundCheck script
        groundDetector.CheckGround();
        bool isGrounded = groundDetector.IsGrounded();

        // Additional logic for airborne behavior can be added here if needed
        if (!isGrounded)
        {
            // Example: Apply additional logic for airborne behavior
        }
    }

    // Called when the CharacterController collides with another collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Ensure the player stops only on obstacles with the "Obstacles" tag
        if (hit.collider.CompareTag("Obstacles"))
        {
            playerCharacterController.Move(Vector3.zero); // Stop movement
            Debug.Log("Player stopped due to collision with: " + hit.collider.gameObject.name);
        }
    }
}