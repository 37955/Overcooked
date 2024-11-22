using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float speed = 70;
    [SerializeField] private float reverseSpeed = 50;
    [SerializeField] private Canvas canvas;

    float currentValue;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (currentValue < 100)
            {
                currentValue += speed * Time.deltaTime;

            }

        }
        else
        {
            if (currentValue > 0)
            {
                currentValue -= reverseSpeed * Time.deltaTime;
            }
        }
        image.fillAmount = currentValue / 100;

        if (currentValue >= 100)
        {
            HideCanvas();
        }
    }

    private void HideCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

}

