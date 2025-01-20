using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseSlider : MonoBehaviour
{

    HoldIngredientCount holdIngredientCountScript;
    [SerializeField] Slider cookSlider;
    private float sliderValue;
    private float increaseCount = 0.1f;
    private float decreaseCount = 50;

    private bool decrease1 = true;
    private bool decrease2 = true;

    private void Start()
    {
        holdIngredientCountScript = GetComponent<HoldIngredientCount>();
    }

    private void Update()
    {
        if (holdIngredientCountScript.ingredientCount >= 1)
        {
            IncreaseValue();
            if (holdIngredientCountScript.ingredientCount == 2)
            {
                if (decrease1)
                {
                    decreaseValue();
                    decrease1 = false;
                }
            }
            if (holdIngredientCountScript.ingredientCount == 3)
            {
                if (decrease2)
                {
                    decreaseValue();
                    decrease2 = false;
                }
            }
        }
    }

    void updateSlider()
    {
        cookSlider.value = sliderValue;
    }
    void IncreaseValue()
    {
        sliderValue += increaseCount;
        updateSlider();
    }
    void decreaseValue()
    {
       sliderValue -= decreaseCount;
       updateSlider();
    }


}
