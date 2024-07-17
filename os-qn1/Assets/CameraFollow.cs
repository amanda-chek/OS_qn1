using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;             // Reference to the player's transform
    public Vector3 offset;               // Offset position of the camera relative to the player
    public float smoothSpeed = 0.125f;   // Smoothing speed for camera movement
    public bool lookAtPlayer = true;     // Whether the camera should always look at the player

    private Vector3 currentVelocity;     // Velocity vector for SmoothDamp

    void LateUpdate()
    {
        // Calculate the target position the camera should move towards
        Vector3 targetPosition = player.position + offset;

        // Smoothly interpolate between current position and target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed);

        // Optionally, make the camera always look at the player if they are not too close
        if (lookAtPlayer)
        {
            // Calculate the direction from camera to player
            Vector3 directionToPlayer = player.position - transform.position;

            // Ensure directionToPlayer is not zero before calculating rotation
            if (directionToPlayer.sqrMagnitude > 0.01f) // use a small threshold to avoid jittering
            {
                // Get the target rotation towards the player
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

                // Smoothly rotate towards the player's direction only on the Y-axis
                Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

                // Apply the rotation only around the Y-axis to avoid tilting the camera
                transform.rotation = Quaternion.Euler(0, smoothedRotation.eulerAngles.y, 0);
            }
        }
    }
}
