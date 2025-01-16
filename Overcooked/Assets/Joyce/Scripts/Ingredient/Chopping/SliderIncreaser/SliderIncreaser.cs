using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SliderIncreaser : MonoBehaviour
{
    [SerializeField] Slider theChopSlider;
    [SerializeField] IngredientCollisionDetector collisionDetectorScript;
    private GameObject[] players = new GameObject[1];
    private float sliderValue;
    private float increaseValue = 5;
    private float theTime;
    private float resetTime = 0.3f;

    private void Start()
    {
        sliderValue = 0;
        UpdateTheSlider();

    }

    private void Update()
    {
        theTime += Time.deltaTime;
     
        {
            if (theTime >= resetTime && collisionDetectorScript.TouchesChopCounter && collisionDetectorScript.TouchesPlayer)
            {
                IncreaseTheSlider();
                ResetTheTime();
            }
        }
    }
    void UpdateTheSlider()
    {
        theChopSlider.value = sliderValue;
    }
    void IncreaseTheSlider()
    {
        if (sliderValue != 100 && sliderValue !> 100)
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
