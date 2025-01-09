using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SliderIncreaser : MonoBehaviour
{
    [SerializeField] Slider theChopSlider;
  
    private float sliderValue;
    private float increaseValue = 15;
    [SerializeField]private float theTime;
    private float resetTime = 0.3f;

    private void Start()
    {
        sliderValue = 0;
        UpdateTheSlider();
    }

    private void Update()
    {
        theTime += Time.deltaTime;

        if (theTime >= resetTime)
        {
            IncreaseTheSlider();
            ResetTheTime();
        }
    }
    void UpdateTheSlider()
    {
        theChopSlider.value = sliderValue;
    }
    void IncreaseTheSlider()
    {
        if (sliderValue != 100)
        {
            sliderValue += increaseValue;
            UpdateTheSlider();
        }
    }
    void ResetTheTime()
    {
        theTime = 0;
    }
}
