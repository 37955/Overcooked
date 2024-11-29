using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform activePlayer; // Reference to the currently active player's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Default offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement

    private Vector3 velocity = Vector3.zero; // Used for SmoothDamp

    private void LateUpdate()
    {
        if (activePlayer == null) return;

        // Calculate the target position based on the active player's position and the offset
        Vector3 targetPosition = activePlayer.position + offset;

        // Smoothly move the camera to the target position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }

    public void SetActivePlayer(Transform newActivePlayer)
    {
        activePlayer = newActivePlayer;
    }
}
