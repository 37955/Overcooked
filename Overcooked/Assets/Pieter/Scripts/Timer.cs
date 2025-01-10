using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timerDuration = 150f; 
    private float currentTime;
    public TMP_Text timerText; 
    public AudioSource beepSound; 
    public AudioSource backgroundMusic;

    //Fields and variables: booleans die vragen beantwoorden.
    private bool isBeeping = false; 
    private bool hasSpedUpMusic = false; 

    void Start()
    {
        currentTime = timerDuration;
        isBeeping = false;
        hasSpedUpMusic = false;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0); 
            UpdateTimerUI();

            if (currentTime <= 30 && !hasSpedUpMusic)
            {
                SpeedUpMusic();
            }

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
            int minutes = Mathf.FloorToInt(currentTime / 60); 
            int seconds = Mathf.FloorToInt(currentTime % 60); 
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
    }

    void SpeedUpMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.pitch = 1.25f; 
        }
        hasSpedUpMusic = true;
    }

    void StartBeeping()
    {
        if (beepSound != null)
        {
            beepSound.Play(); 
        }
        isBeeping = true;
        Invoke("ResetBeeping", 1f);
    }

    void ResetBeeping()
    {
        isBeeping = false;
    }
}
