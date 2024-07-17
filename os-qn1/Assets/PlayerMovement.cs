using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 10f;    // Acceleration rate
    public float maxSpeed = 5f;         // Maximum movement speed
    public float rotationSpeed = 360f;  // Speed of rotation
    public float deceleration = 5f;     // Deceleration rate

    private Rigidbody rb;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction relative to the player's rotation
        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;

        // Normalize movement vector if needed
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Calculate target velocity based on input and acceleration
        Vector3 targetVelocity = movement * maxSpeed;

        // Smoothly adjust velocity based on acceleration
        velocity = Vector3.Lerp(velocity, targetVelocity, acceleration * Time.deltaTime);

        // Decelerate to stop smoothly when no input
        if (movement.magnitude == 0)
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Move the player
        rb.MovePosition(transform.position + velocity * Time.deltaTime);

        // Rotate the player towards movement direction
        if (movement.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
