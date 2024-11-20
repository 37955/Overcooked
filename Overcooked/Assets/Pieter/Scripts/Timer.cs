using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timerDuration = 10f; // Set this in the Inspector
    private float currentTime;
    public TMP_Text timerText; // Reference to a TextMeshProUGUI object

    void Start()
    {
        currentTime = timerDuration;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0); // Clamp to 0 to avoid negative values
            UpdateTimerUI();
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
}
