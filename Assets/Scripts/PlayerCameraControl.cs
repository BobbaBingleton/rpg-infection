using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public float mouseSensitivity = 2f; // Mouse sensitivity for looking around
    public float verticalLookLimit = 80f; // Vertical look limit (degrees)

    private float xRotation = 0f; // Store the current X rotation (vertical look)
    private Transform playerBody; // Reference to the player's body (to rotate the player)

    void Start()
    {
        playerBody = transform.parent; // The camera is usually a child of the player
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    void Update()
    {
        HandleCameraMovement();
    }

    void HandleCameraMovement()
    {
        // Get mouse input for looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Apply mouse X movement to rotate the player body (horizontal look)
        playerBody.Rotate(Vector3.up * mouseX);

        // Apply mouse Y movement to control vertical look with limits
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit); // Clamp the vertical look

        // Apply the vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
