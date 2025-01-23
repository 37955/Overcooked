using UnityEngine;

public class CookingParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem cookEffect;
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
        if (cookEffect != null && !cookEffect.isPlaying)
        {
            cookEffect.Play();
        }
    }

    private void StopSmokeEffect()
    {
        if (cookEffect != null && cookEffect.isPlaying)
        {
            cookEffect.Stop();
        }
    }
}
