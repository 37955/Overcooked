using UnityEngine;
using UnityEngine.UI;

public class enableObject : MonoBehaviour
{
    [SerializeField] Slider theSlider;
    [SerializeField] GameObject theObjectThatNeedsToBeAcitve;

    private void Update()
    {
        if (theSlider.value <= 0)
        {
            theObjectThatNeedsToBeAcitve.SetActive(true);
        }
    }
}
