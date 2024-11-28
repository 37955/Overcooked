using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private float dashTimeLeft;
    private float dashCooldownTime;
    private float dustDashTimeLeft;

    private Vector3 moveDirection;
    private Rigidbody rb;

    public ParticleSystem dustTrail;
    public ParticleSystem dustDash;
    public AudioClip dashSound;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleDash();
        HandleDustTrail();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            float currentSpeed = (dashTimeLeft > 0) ? dashSpeed : moveSpeed;

            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            transform.Translate(Vector3.zero, Space.World);
        }
    }

    private void HandleDash()
    {
        if (dashTimeLeft > 0)
        {
            dashTimeLeft -= Time.deltaTime;
            dustDashTimeLeft -= Time.deltaTime;
        }
        else
        {
            dashCooldownTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && dashCooldownTime <= 0 && moveDirection.magnitude > 0.1f)
        {
            dashTimeLeft = dashDuration;
            dashCooldownTime = dashCooldown;
            dustDashTimeLeft = dashDuration;

            if (dustDash != null)
            {
                dustDash.Play();
            }

            if (dashSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(dashSound);
            }
        }

        if (dustDashTimeLeft <= 0 && dustDash != null && dustDash.isPlaying)
        {
            dustDash.Stop();
        }
    }

    private void HandleDustTrail()
    {
        if (dustTrail == null) return;

        if (moveDirection.magnitude > 0.1f)
        {
            if (!dustTrail.isPlaying)
                dustTrail.Play();
        }
        else
        {
            if (dustTrail.isPlaying)
                dustTrail.Stop();
        }
    }
}
