using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanCookState : MonoBehaviour
{
    [SerializeField] StateCheckerIngredient stateCheckerScript;
    [SerializeField] Slider theChopSlider;

    private void Update()
    {
        if (theChopSlider.value >= 100)
        {
            stateCheckerScript.CanChop = false;
            stateCheckerScript.CanCook = true;
        }
    }
}
