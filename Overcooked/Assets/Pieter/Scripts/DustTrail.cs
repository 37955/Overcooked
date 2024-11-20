using UnityEngine;

public class DustTrail : MonoBehaviour
{
    public ParticleSystem dustTrail;
    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerRigidbody.linearVelocity.magnitude > 0.1f)
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
