using UnityEngine;
using UnityEngine.UI;

public class GetChoppedIngredient : MonoBehaviour
{
    [SerializeField] Slider theChopSlider;
    [SerializeField] GameObject choppedIngredient;
    private void Update()
    {
        if (theChopSlider.value == 100)
        {
            choppedIngredient.SetActive(true);
        }
    }
}
