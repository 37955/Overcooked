using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CookingSliderEnabler : MonoBehaviour
{
    HoldIngredientCount holdingIngredientCountScript;
    [SerializeField] GameObject cookingSlider;
    [SerializeField] GameObject soupMesh;

    private void Start()
    {
        holdingIngredientCountScript = GetComponent<HoldIngredientCount>();
    }
    private void Update()
    {
        if (holdingIngredientCountScript.ingredientCount > 0)
        {
            cookingSlider.SetActive(true);
            soupMesh.SetActive(true);
        }

        if (holdingIngredientCountScript.ingredientCount < 1)
        {
            cookingSlider.SetActive(false);
            soupMesh.SetActive(false);
        }
    }
}
