using UnityEngine;

public class ChoppingParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokeEffect;
    [SerializeField] private ParticleSystem starEffect;
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            StopSmokeEffect();
        }
    }

    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlaySmokeEffect();
        }
    }

    private void PlaySmokeEffect()
    {
        if (smokeEffect != null && !smokeEffect.isPlaying)
        {
            starEffect.Play();
            smokeEffect.Play();
        }
    }

    private void StopSmokeEffect()
    {
        if (smokeEffect != null && smokeEffect.isPlaying)
        {
            starEffect.Stop();
            smokeEffect.Stop();
        }
    }
}
