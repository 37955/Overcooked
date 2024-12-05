using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderCook: MonoBehaviour
{
    [SerializeField] ingredientCount ingredientCountScript;
    [SerializeField] Slider cookingSlider;
    [SerializeField] float increaseValue;
    [SerializeField] float decreaseValue;
    private float sliderValue;
    private bool decreased1 = false;
    private bool decreased2 = false;
    private void Start()
    {
        updateSlider();
    }
    private void Update()
    {
        increaseSlider();
        if (ingredientCountScript.ingredients == 2 && !decreased1)
        {
            sliderValue -= sliderValue;
            decreased1 = true;
        }
        if (ingredientCountScript.ingredients == 3 && !decreased2)
        {
            sliderValue -= sliderValue;
            decreased2 = true;
        }
    }
    void updateSlider()
    {
        cookingSlider.value = sliderValue;
    }
    void increaseSlider()
    {
        sliderValue += increaseValue = Time.deltaTime;
        updateSlider();
    }
}
