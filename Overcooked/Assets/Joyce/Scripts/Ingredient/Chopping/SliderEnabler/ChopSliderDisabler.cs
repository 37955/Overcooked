using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChopSliderDisabler : MonoBehaviour
{
    [SerializeField] Slider theChopSlider;
    [SerializeField] GameObject onionBody;

    private void Update()
    {
        if (theChopSlider.value == 100)
        {
            onionBody.SetActive(false);
        }
    }
}
