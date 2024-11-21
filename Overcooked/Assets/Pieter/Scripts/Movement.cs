using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;     // Normal movement speed
    public float dashSpeed = 15f;    // Dash speed
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f;  // Cooldown time for dashing

    private float dashTimeLeft;      // Remaining dash time
    private float dashCooldownTime;  // Time until next dash is available
    private float dustDashTimeLeft;  // Time left for the dust dash effect

    private Vector3 moveDirection;  // Current movement direction
    private Rigidbody rb;           // Reference to the Rigidbody

    public ParticleSystem dustTrail;  // Reference to the Particle System for the dust trail
    public ParticleSystem dustDash;   // Reference to the Particle System for the dust dash effect

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure we have a Rigidbody reference
    }

    private void Update()
    {
        HandleMovement();
        HandleDash();
        HandleDustTrail(); // Manage the dust trail
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
            dustDashTimeLeft -= Time.deltaTime;  // Decrease the dust dash timer
        }
        else
        {
            dashCooldownTime -= Time.deltaTime;
        }

        // Start dash if E is pressed, dash is ready, and the player is moving
        if (Input.GetKeyDown(KeyCode.E) && dashCooldownTime <= 0 && moveDirection.magnitude > 0.1f)
        {
            dashTimeLeft = dashDuration;       // Activate dash
            dashCooldownTime = dashCooldown;   // Start cooldown
            dustDashTimeLeft = dashDuration;   // Set dust dash duration to match dash duration

            // Play the DustDash effect only when dash is triggered
            if (dustDash != null)
            {
                dustDash.Play(); // Play the dash particle system
            }
        }

        // Stop DustDash effect when dash is over
        if (dustDashTimeLeft <= 0 && dustDash != null && dustDash.isPlaying)
        {
            dustDash.Stop(); // Stop the dash effect once the dash duration is over
        }
    }


    private void HandleDustTrail()
    {
        if (dustTrail == null) return;

        // Check if the player is actively moving (based on input)
        if (moveDirection.magnitude > 0.1f)
        {
            if (!dustTrail.isPlaying)
                dustTrail.Play(); // Start the particle system when moving
        }
        else
        {
            if (dustTrail.isPlaying)
                dustTrail.Stop(); // Stop the particle system when standing still
        }
    }
}
