using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;     // Normal movement speed
    public float dashSpeed = 15f;   // Dash speed
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown time for dashing

    private float dashTimeLeft;     // Remaining dash time
    private float dashCooldownTime; // Time until next dash is available

    private Vector3 moveDirection; // Current movement direction

    private void Update()
    {
        HandleMovement();
        HandleDash();
    }

    private void HandleMovement()
    {
        // Get input from W, A, S, D keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement direction vector
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Move the player
        if (moveDirection.magnitude > 0.1f)
        {
            float currentSpeed = (dashTimeLeft > 0) ? dashSpeed : moveSpeed; // Use dash speed if dashing
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);

            // Make the player look in the direction they're moving
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    private void HandleDash()
    {
        // Reduce dash duration and cooldown timers
        if (dashTimeLeft > 0)
        {
            dashTimeLeft -= Time.deltaTime;
        }
        else
        {
            dashCooldownTime -= Time.deltaTime;
        }

        // Start dash if E is pressed and dash is ready
        if (Input.GetKeyDown(KeyCode.E) && dashCooldownTime <= 0)
        {
            dashTimeLeft = dashDuration;    // Activate dash
            dashCooldownTime = dashCooldown; // Start cooldown
        }
    }
}
