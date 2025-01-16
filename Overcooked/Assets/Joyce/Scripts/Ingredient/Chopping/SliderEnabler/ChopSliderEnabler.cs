using UnityEngine;

public class ChopSliderEnabler : MonoBehaviour
{
    [SerializeField] GameObject theChopSlider;
    [SerializeField] StateCheckerIngredient stateScriptIngredient;
    [SerializeField] IngredientCollisionDetector collisionDetectorScript;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && stateScriptIngredient.CanChop && collisionDetectorScript.TouchesChopCounter)
        {
            enableTheSlider();
        }
    }

    void enableTheSlider()
    {
        theChopSlider.SetActive(true);
    }
}
