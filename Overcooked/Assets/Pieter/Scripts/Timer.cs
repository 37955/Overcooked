using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timerDuration = 10f; // Set this in the Inspector
    private float currentTime;
    public TMP_Text timerText; // Reference to a TextMeshProUGUI object
    public AudioSource beepSound; // Reference to an AudioSource for the beep sound

    private bool isBeeping = false; // Flag to ensure the beeping sound is played only once per second

    void Start()
    {
        currentTime = timerDuration;
        isBeeping = false;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0); // Clamp to 0 to avoid negative values
            UpdateTimerUI();

            // Check if the timer is 10 seconds or less
            if (currentTime <= 10 && !isBeeping)
            {
                StartBeeping();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60); // Calculate minutes
            int seconds = Mathf.FloorToInt(currentTime % 60); // Calculate seconds
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format as MM:SS
        }
    }

    void StartBeeping()
    {
        if (beepSound != null)
        {
            beepSound.Play(); // Play the beep sound
        }
        isBeeping = true; // Prevent multiple plays in the same second
        Invoke("ResetBeeping", 1f); // Reset the flag after 1 second
    }

    void ResetBeeping()
    {
        isBeeping = false;
    }
}
