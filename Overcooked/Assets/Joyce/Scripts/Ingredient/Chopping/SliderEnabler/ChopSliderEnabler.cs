using UnityEngine;

public class ChopSliderEnabler : MonoBehaviour
{
    [SerializeField] GameObject theChopSlider;
    [SerializeField] StateCheckerIngredient stateScriptIngredient;
    [SerializeField] IngredientCollisionDetector collisionDetectorScript;
    private bool canEnableSlider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ChopCounter"))
        {
            canEnableSlider = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && stateScriptIngredient.CanChop &&canEnableSlider && collisionDetectorScript.TouchesChopCounter)
        {
            enableTheSlider();
        }
    }

    void enableTheSlider()
    {
        theChopSlider.SetActive(true);
    }
}
