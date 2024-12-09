using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;

    private Vector3 movementDirection;

    private void Start()
    {
        // Calculate the initial forward direction.
        movementDirection = characterController.transform.forward;
    }

    private void Update()
    {
        // Get the horizontal and vertical input axes.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate the player based on the horizontal input axis.
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Update the forward and backward direction based on the player's rotation.
        movementDirection = characterController.transform.forward;

        // Move the character controller based on the vertical input axis.
        characterController.Move(movementDirection * verticalInput * movementSpeed * Time.deltaTime);
    }
}