using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Default offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public float dragFactor = 0.1f; // Factor to control the "drag" effect

    public Vector3 minBound = new Vector3(-5, 0, -5); // Minimum camera bounds (left, down, forward)
    public Vector3 maxBound = new Vector3(5, 0, 5); // Maximum camera bounds (right, up, back)

    private Vector3 velocity = Vector3.zero; // Used for smooth damp
    private Vector3 previousPlayerPosition; // For calculating the player's movement

    private void Start()
    {
        // Ensure player is assigned
        if (player == null)
        {
            player = GameObject.Find("Player").transform; // Find the player if not assigned
        }

        // Initialize previous player position
        previousPlayerPosition = player.position;
    }

    private void Update()
    {
        // Calculate player movement (this will give us the "drag" effect)
        Vector3 playerMovement = player.position - previousPlayerPosition;

        // Update previous player position
        previousPlayerPosition = player.position;

        // Calculate the target camera position based on the player's position and the offset
        Vector3 targetPosition = player.position + offset;

        // Apply slight movement (drag) in the x, y, and z directions based on the player's movement
        Vector3 subtleMovement = new Vector3(
            playerMovement.x * 0.1f,  // Slight horizontal movement (left/right)
            0,                         // Keep y-axis stable (no up/down movement)
            playerMovement.z * 0.1f   // Slight forward/backward movement
        );

        // Apply the "drag" effect using SmoothDamp for smooth following
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition + subtleMovement, ref velocity, dragFactor);

        // Constrain the camera's position within the bounds
        smoothedPosition = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minBound.x, maxBound.x),
            Mathf.Clamp(smoothedPosition.y, minBound.y, maxBound.y),
            Mathf.Clamp(smoothedPosition.z, minBound.z, maxBound.z)
        );

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
