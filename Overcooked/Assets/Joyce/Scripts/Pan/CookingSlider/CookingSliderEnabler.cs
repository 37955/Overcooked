using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CookingSliderEnabler : MonoBehaviour
{
    HoldIngredientCount holdingIngredientCountScript;
    [SerializeField] GameObject cookingSlider;

    private void Start()
    {
        holdingIngredientCountScript = GetComponent<HoldIngredientCount>();
    }
    private void Update()
    {
        if (holdingIngredientCountScript.ingredientCount > 0)
        {
            cookingSlider.SetActive(true);
        }
    }
}
