using UnityEngine;

public class SimplePlayerMovementNoJump : MonoBehaviour
{
    public float walkSpeed = 3f;  // Speed while walking
    public float sprintSpeed = 6f; // Speed while sprinting

    private float moveSpeed;      // Current movement speed
    private Rigidbody rb;         // Player's Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        moveSpeed = walkSpeed;  // Start with walking speed
    }

    void Update()
    {
        HandleMovement();
        HandleSprinting();
    }

    void HandleMovement()
    {
        // Get horizontal and vertical input (WASD / Arrow Keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector based on player input
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player if there is input
        if (moveDirection.magnitude >= 0.1f)
        {
            // Apply the movement force
            Vector3 move = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
        }
    }

    void HandleSprinting()
    {
        // Check if the Shift key is pressed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = sprintSpeed;  // Set movement speed to sprint speed
        }
        else
        {
            moveSpeed = walkSpeed;  // Otherwise, set to walk speed
        }
    }
}
