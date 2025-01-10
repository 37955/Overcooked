using UnityEngine;

public class ChopSliderEnabler : MonoBehaviour
{
    [SerializeField] GameObject theChopSlider;
    [SerializeField] StateCheckerIngredient stateScriptIngredient;
    private bool canEnableSlider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ChopCounter"))
        {
            Debug.Log("can enable the slider");
            canEnableSlider = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && stateScriptIngredient.CanChop &&canEnableSlider)
        {
            enableTheSlider();
        }
    }

    void enableTheSlider()
    {
        theChopSlider.SetActive(true);
        Debug.Log("enabled the slider");
    }
}
