using UnityEngine;
using UnityEngine.UI;

public class ingredientCount : MonoBehaviour
{
    [SerializeField] GameObject[] iconsEmpty;
    [SerializeField] GameObject[] iconsIngredient;
    [SerializeField] Slider theCookingSlider;

    private GameObject theSlider;
    public float ingredients = 0;

    private void Start()
    {
        theSlider = theCookingSlider.gameObject;
        foreach (GameObject icons in iconsEmpty)
        {
            icons.SetActive(true);
        }

        foreach (GameObject icon in iconsIngredient)
        {
            icon.SetActive(false);
        }
    }

    private void Update()
    {
        if (ingredients == 0)
        {
            iconsEmpty[0].SetActive(true);
            iconsEmpty[1].SetActive(true);
            iconsEmpty[2].SetActive(true);

            iconsIngredient[0].SetActive(false);
            iconsIngredient[1].SetActive(false);
            iconsIngredient[2].SetActive(false);
        }

        if (ingredients == 1)
        {
            iconsEmpty[0].SetActive(false);
            iconsIngredient[0].SetActive(true);
        }

        if (ingredients == 2)
        {
            iconsEmpty[1].SetActive(false);
            iconsIngredient[1].SetActive(true);
        }
        if (ingredients == 3)
        {
            iconsEmpty[2].SetActive(false);
            iconsIngredient[2].SetActive(true);
        }

        if (ingredients == 1)
        {
            theSlider.SetActive(true);
        }
        
    }
}
