using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class deleteObject : MonoBehaviour
{
    [SerializeField] Slider theChopSlider;

    void Update()
    {
        if (theChopSlider.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}


